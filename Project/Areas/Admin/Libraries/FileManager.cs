using KanunWebsite.Areas.Admin.Libraries.Repository;

namespace KanunWebsite.Areas.Admin.Libraries
{
    public class FileManager : IFileManager
    {
        private const string _PATH = "Uploads";
        private const string _ROOT = "wwwroot";
        public void Delete(string fileName)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(),_ROOT,_PATH,fileName);
            if(File.Exists(path))
            {
                File.Delete(path);
            }
        }

        public bool FileExists(string fileName)
        {
            return File.Exists(Path.Combine(Directory.GetCurrentDirectory(), _ROOT, _PATH, fileName));
        }

        public string Upload(IFormFile file, string fileName = "")
        {
            string[] list = file.FileName.Split('.');
            string newName;
            if (fileName == "")
            {
                newName = $"{Guid.NewGuid()}.{list[^1]}";
            }
            else 
            {
                newName = $"{fileName}.{list[^1]}";
            }
            var writePath = Path.Combine(Directory.GetCurrentDirectory(), _ROOT, _PATH);
            if (!Directory.Exists(writePath))      
            Directory.CreateDirectory(writePath);
            var path = Path.Combine(writePath,newName);
            using var stream = new FileStream(path, FileMode.Create);
            file.CopyTo(stream);
            return newName;
        }
    }
}
