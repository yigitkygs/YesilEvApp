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
        public List<CategoryDTO> GetAllCategories()
        {
            List<CategoryDTO> dto = new List<CategoryDTO>();
            try
            {
                dto = MyMapper.ListCategoryToListCategoryDTO(new CategoryDAL().GetAll().Where(a => a.IsActive == true).ToList());
            }

            catch (Exception e)
            {
                Console.WriteLine("Hata: GetAllCategories");
            }
            return dto;
        }
        public List<CategoryDTO> GetAllCategoriesAdmin()
        {
            List<CategoryDTO> dto = new List<CategoryDTO>();
            try
            {
                dto = MyMapper.ListCategoryToListCategoryDTO(new CategoryDAL().GetAll());
            }

            catch (Exception e)
            {
                Console.WriteLine("Hata: GetAllCategoriesAdmin");
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
                Console.WriteLine("Hata: GetCategoryFromID");
            }
            return gonderilecek;
        }
        public bool AddNewCategory(CategoryDTO dto)
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
                Console.WriteLine("Hata: AddNewCategory");
            }
            return false;
        }
        public void UpdateCategory(CategoryDTO dto)
        {
            try
            {
                CategoryDAL dal = new CategoryDAL();
                dal.Update(MyMapper.CategoryDTOToCategory(dto),dto.CategoryID);
                dal.MySaveChanges();
            }

            catch (Exception e)
            {
                Console.WriteLine("Hata: UpdateCategory");
            }
        }
        

        public void SoftDeleteCategory(CategoryDTO dto)
        {
            try
            {
                CategoryDAL dal = new CategoryDAL();
                dto.IsActive = false;
                dal.Update(MyMapper.CategoryDTOToCategory(dto), dto.CategoryID);
                dal.MySaveChanges();
            }

            catch (Exception e)
            {
                Console.WriteLine("Hata: UpdateCategory");
            }
        }
        public void RevertSoftDeleteCategory(CategoryDTO dto)
        {
            try
            {
                CategoryDAL dal = new CategoryDAL();
                dto.IsActive = true;
                dal.Update(MyMapper.CategoryDTOToCategory(dto), dto.CategoryID);
                dal.MySaveChanges();
            }

            catch (Exception e)
            {
                Console.WriteLine("Hata: RevertSoftDeleteCategory");
            }
        }

        public bool HardDeleteCategory(CategoryDTO dto)
        {
            try
            {
                CategoryDAL dal = new CategoryDAL();
                dal.Delete(MyMapper.CategoryDTOToCategory(dto));
                dal.MySaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: HardDeleteCategory");
            }
            return false;
        }
    }
}
