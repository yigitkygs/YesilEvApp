using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YesilEvAppYigit.DTO;

namespace YesilEvAppYigit.Validation
{
    public class NewProductValidation : ValidationBase<ProductDTO>
    {
        public NewProductValidation(ProductDTO model) : base(model)
        {
        }

        protected override void OnValidate()
        {
            CheckBarcode();
            CheckProductName();
            CheckBrand();
            CheckCategory();
            CheckProductIngredients(); 
        }
        private void CheckBarcode()
        {
            if (Model.BarcodeNo.Length<16)
            {
                IsValid = false;
                ValidationMessages.Add("Barkod en az 16 haneli olarak girilmeli.");
            }
        }
        private void CheckProductName()
        {
            if (Model.ProductName.Length == 0 || Model.ProductName.Length > 100)
            {
                IsValid = false;
                ValidationMessages.Add("Ürünün Adı uzunluğu 0'dan büyük ve 100'den küçük olmalıdır.");
            }
        }
        private void CheckBrand()
        {
            if (Model.BrandID == -1)
            {
                IsValid = false;
                ValidationMessages.Add("Üretici seçilmesi gerekiyor.");
            }
        }
        private void CheckCategory()
        {
            if (Model.CategoryID == -1)
            {
                IsValid = false;
                ValidationMessages.Add("Kategori seçilmesi gerekiyor.");
            }
        }
        private void CheckProductIngredients()
        {
            if (Model.ProductAllergens.Count == 0)
            {
                IsValid = false;
                ValidationMessages.Add("Ürün içeriği boş olamaz.");
            }
        }
    }
}
