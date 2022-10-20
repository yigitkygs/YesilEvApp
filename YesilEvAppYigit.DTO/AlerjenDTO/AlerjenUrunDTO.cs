using System.ComponentModel;

namespace YesilEvAppYigit.DTO
{
    public class AlerjenUrunDTO
    {
        [DisplayName("Alerjen Adı")]

        public string AlerjenAdi { get; set; }

        [DisplayName("Ürün Adı")]

        public string UrunAdi { get; set; }
    }
}