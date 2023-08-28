using System.ComponentModel.DataAnnotations.Schema;

namespace AngerTravelTours.Models
{
    public class TourPackage:BaseEntities
    {
        public TourPackage()
        {
            InitiateDictionary();
        }

        private readonly IDictionary<decimal, string> starCode = new Dictionary<decimal, string>();
        public string Image { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Desc { get; set; } = string.Empty;
        [Column(TypeName ="money")]
        public decimal Price { get; set; }
        [Column(TypeName="tinyint")]
        public byte Day { get; set; }
        [Column(TypeName = "tinyint")]
        public byte Night { get; set; }
        public decimal Rating { get; set; } = 0;

        private void InitiateDictionary()
        {
            starCode.Add(0M, "ion-android-star-outline");
            starCode.Add(0.5M, "ion-android-star-halfs"); //Don't forget the M
            starCode.Add(1M, "ion-android-star");
        }

        public List<string> ReturnReview()
        {
            List<string>? rates = default;
            if (Rating <= 5)
            {
                if(Rating % 1 == 0)
                {
                    for (int i = 0; i <= Rating; i++)
                    {
                        rates?.Add(starCode[i]);
                    }
                }
                else
                {

                }
            }
            return rates!;
           // throw new Exception("Return review unable to return rating");
        }
    }
}
