using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YesilEvAppYigit.Core;
using YesilEvAppYigit.Core.Repos;
using YesilEvAppYigit.DTO;
using YesilEvAppYigit.Mapping;

namespace YesilEvAppYigit.DAL.Concrete
{
    public class ProductAllergenDAL : RepoBase<YesilEvDbContext, ProductAllergen>
    {
        public List<ProductAllergenDTO> GetAllProductAllergens()
        {
            List<ProductAllergenDTO> dto = new List<ProductAllergenDTO>();
            try
            {
                dto = MyMapper.ListProductAllergenToListProductAllergenDTO(new ProductAllergenDAL().GetAll().Where(a => a.IsActive == true).ToList());
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: GetAllProductAllergens");
            }
            return dto;
        }
        public List<ProductAllergenDTO> GetAllProductAllergensAdmin()
        {
            List<ProductAllergenDTO> dto = new List<ProductAllergenDTO>();
            try
            {
                dto = MyMapper.ListProductAllergenToListProductAllergenDTO(new ProductAllergenDAL().GetAll());
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: GetAllProductAllergensAdmin");
            }
            return dto;
        }

        public List<ProductAllergenDTO> GetProductAllergensBy(Func<ProductAllergen, bool> cond)
        {
            List<ProductAllergenDTO> dto = new List<ProductAllergenDTO>();
            try
            {
                dto = MyMapper.ListProductAllergenToListProductAllergenDTO(new ProductAllergenDAL().GetBy(cond));
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: GetProductAllergensBy");
            }
            return dto;
        }
        public ProductAllergenDTO GetProductAllergenFromID(object ID)
        {
            ProductAllergenDTO gonderilecek = new ProductAllergenDTO();
            try
            {
                gonderilecek = MyMapper.ProductAllergenToProductAllergenDTO(new ProductAllergenDAL().GetByID(ID));
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: GetProductAllergenFromID");
            }
            return gonderilecek;
        }
        public List<ProductAllergenDTO> GetProductAllergenFromProductID(object ID)
        {
            List<ProductAllergenDTO> dto = new List<ProductAllergenDTO>();
            try
            {
                dto = new ProductAllergenDAL().GetProductAllergensBy(a => a.ProductID == (int)ID && a.IsActive == true)
                    .Join(new AllergenDAL()
                    .GetAllAllergens(), a => a.AllergenID, b => b.AllergenID, (a, b) => new ProductAllergenDTO()
                    {
                        AllergenID = a.AllergenID,
                        IsActive = a.IsActive,
                        ProductID = a.ProductID,
                        CreateDate = a.CreateDate,
                        Allergen = b,
                        ProductAllergenID=a.ProductAllergenID
                    }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: GetProductAllergenFromID");
            }
            return dto;
        }
        public bool AddNewProductAllergen(ProductAllergenDTO dto)
        {
            try
            {
                ProductAllergenDAL dal = new ProductAllergenDAL();
                dal.Add(MyMapper.ProductAllergenDTOToProductAllergen(dto));
                dal.MySaveChanges();
                return true;
            }

            catch (Exception e)
            {
                Console.WriteLine("Hata: AddNewProductAllergen");
            }
            return false;
        }
        public void UpdateProductAllergen(ProductAllergenDTO dto)
        {
            try
            {
                ProductAllergenDAL dal = new ProductAllergenDAL();
                dal.Update(MyMapper.ProductAllergenDTOToProductAllergen(dto),dto.ProductAllergenID);
                dal.MySaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: UpdateProductAllergen");
            }
        }
        public void SoftDeleteProductAllergen(ProductAllergenDTO dto)
        {
            try
            {
                ProductAllergenDAL dal = new ProductAllergenDAL();
                dto.IsActive = false;
                dal.Update(MyMapper.ProductAllergenDTOToProductAllergen(dto));
                dal.MySaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: SoftDeleteProductAllergen");
            }
        }
        public void RevertSoftDeleteProductAllergen(ProductAllergenDTO dto)
        {
            try
            {
                ProductAllergenDAL dal = new ProductAllergenDAL();
                dto.IsActive = true;
                dal.Update(MyMapper.ProductAllergenDTOToProductAllergen(dto));
                dal.MySaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: RevertSoftDeleteProductAllergen");
            }
        }
        public bool HardDeleteProductAllergen(ProductAllergenDTO dto)
        {
            try
            {
                ProductAllergenDAL dal = new ProductAllergenDAL();
                dal.Delete(MyMapper.ProductAllergenDTOToProductAllergen(dto));
                dal.MySaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: HardDeleteProductAllergen");
            }
            return false;
        }
    }
}
