using YesilEvAppYigit.Core;

namespace YesilEvAppYigit.DTO
{
    public class UrunRiskFavoriDTO
    {
        public int AllergenID { get; set; }
        public string AllergenAdi { get; set; }
        public int? RiskID { get; set; }
        public int? UrunID { get; set; }
        public int? FavoriID { get; set; }

        public ProductDTO Urun { get; set; }

        public FavoriteDTO Favori { get; set; }
    }
}