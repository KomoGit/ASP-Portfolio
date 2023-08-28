namespace AngerTravelTours.Models
{
    public class User:BaseEntities
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Image { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Desc { get; set; }
        public List<Blog> Blogs { get; set; }
    }
}
