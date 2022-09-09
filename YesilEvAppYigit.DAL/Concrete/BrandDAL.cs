using AutoMapper;
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
    public class BrandDAL : RepoBase<YesilEvDbContext, Brand>
    {
        public List<BrandDTO> GetAllBrands()
        {
            List<BrandDTO> dto = new List<BrandDTO>();
            try
            {
                dto = MyMapper.ListBrandToListBrandDTO(new BrandDAL().GetAll().Where(a=>a.IsActive==true).ToList());
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: GetAllBrands");
            }
            return dto;
        }
        public List<BrandDTO> GetAllBrandsAdmin()
        {
            List<BrandDTO> dto = new List<BrandDTO>();
            try
            {
                dto = MyMapper.ListBrandToListBrandDTO(new BrandDAL().GetAll());
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: GetAllBrandsAdmin");
            }
            return dto;
        }
        public BrandDTO GetBrandFromID(object ID)
        {
            BrandDTO gonderilecek = new BrandDTO();
            try
            {
                gonderilecek = MyMapper.BrandToBrandDTO(new BrandDAL().GetByID(ID));
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: GetBrandFromID");
            }
            return gonderilecek;
        }
        public bool AddNewBrand(BrandDTO dto)
        {
            try
            {
                BrandDAL dal = new BrandDAL();
                dal.Add(MyMapper.BrandDTOToBrand(dto));
                dal.MySaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: AddNewBrand");
            }
            return false;
        }
        public void UpdateBrand(BrandDTO dto)
        {
            try
            {
                BrandDAL dal = new BrandDAL();
                dal.Update(MyMapper.BrandDTOToBrand(dto));
                dal.MySaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: UpdateBrand");
            }
        }
        public void SoftDeleteBrand(BrandDTO dto)
        {
            try
            {
                BrandDAL dal = new BrandDAL();
                dto.IsActive = false;
                dal.Update(MyMapper.BrandDTOToBrand(dto));
                dal.MySaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: SoftDeleteBrand");
            }
        }
        public void RevertSoftDeleteBrand(BrandDTO dto)
        {
            try
            {
                BrandDAL dal = new BrandDAL();
                dto.IsActive = true;
                dal.Update(MyMapper.BrandDTOToBrand(dto));
                dal.MySaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: RevertSoftDeleteBrand");
            }
        }
        public bool HardDeleteBrand(BrandDTO dto)
        {
            try
            {
                BrandDAL dal = new BrandDAL();
                dal.Delete(MyMapper.BrandDTOToBrand(dto));
                dal.MySaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: HardDeleteBrand");
            }
            return false;
        }
    }
}
