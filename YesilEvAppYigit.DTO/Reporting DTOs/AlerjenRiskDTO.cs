using System.ComponentModel;

namespace YesilEvAppYigit.DTO
{
    public class AlerjenRiskDTO
    {
        [DisplayName("Alerjen Adı")]

        public string AllergenAdi { get; set; }


        public string Risk { get; set; }


        public int Derecesi { get; set; }
    }
}