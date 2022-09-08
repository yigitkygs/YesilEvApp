using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YesilEvAppYigit.Core.Repos;
using YesilEvAppYigit.Core;
using YesilEvAppYigit.DTO;
using YesilEvAppYigit.Mapping;

namespace YesilEvAppYigit.DAL.Concrete
{
    public class CategoryDAL : RepoBase<YesilEvDbContext, Category>
    {
        public CategoryDAL()
        {

        }

        public CategoryDAL(YesilEvDbContext db) : base(db)
        {

        }

        public List<CategoryDTO> GetAllCategories()
        {
            List<CategoryDTO> dto = new List<CategoryDTO>();
            try
            {
                dto = MyMapper.ListCategoryToListCategoryDTO( new CategoryDAL().GetAll());
            }

            catch (Exception e)
            {
                Console.WriteLine("Hata: KategorileriGetir");
            }
            return dto;
        }
        public CategoryDTO GetCategoryFromID(object ID)
        {
            CategoryDTO gonderilecek = new CategoryDTO();
            try
            {
                gonderilecek = MyMapper.CategoryToCategoryDTO(new CategoryDAL().GetByID(ID));
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: KategoriGetir");
            }
            return gonderilecek;
        }
        public bool KategoriEkle(CategoryDTO dto)
        {
            try
            {
                CategoryDAL dal = new CategoryDAL();
                dal.Add(MyMapper.CategoryDTOToCategory(dto));
                dal.MySaveChanges();
                return true;
            }

            catch (Exception e)
            {
                Console.WriteLine("Hata: KategoriEkle");
            }
            return false;
        }
        public void KategoriGuncelle(CategoryDTO dto)
        {
            try
            {
                CategoryDAL dal = new CategoryDAL();
                dal.Update(MyMapper.CategoryDTOToCategory(dto));
                dal.MySaveChanges();
            }

            catch (Exception e)
            {
                Console.WriteLine("Hata: KategoriGuncelle");
            }
        }
        public bool KategoriSil(CategoryDTO dto)
        {
            try
            {
                CategoryDAL dal = new CategoryDAL();
                dal.Delete(MyMapper.CategoryDTOToCategory(dto));
                dal.MySaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: KategoriSil");
            }
            return false;
        }
    }
}
