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

namespace YesilEvAppYigit.DAL.Concerete
{
    public class BrandDAL : RepoBase<YesilEvDbContext, Brand>
    {
        public BrandDAL()
        {

        }

        public BrandDAL(YesilEvDbContext db) : base(db)
        {

        }
    
        public List<BrandDTO> GetAllBrands()
        {
            List<BrandDTO> dto = new List<BrandDTO>();
            try
            {
                dto = MyMapper.ListBrandToListBrandDTO(new BrandDAL().GetAll());

            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: MarkalariGetir");
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
                Console.WriteLine("Hata: MarkaGetir");
            }
            return gonderilecek;
        }
        public bool MarkaEkle(BrandDTO dto)
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
                Console.WriteLine("Hata: MarkaEkle");
            }
            return false;
        }
        public void MarkaGuncelle(BrandDTO dto)
        {
            try
            {
                BrandDAL dal = new BrandDAL();
                dal.Update(MyMapper.BrandDTOToBrand(dto));
                dal.MySaveChanges();
            }

            catch (Exception e)
            {
                Console.WriteLine("Hata: MarkaGuncelle");
            }
        }
        public bool MarkaSil(BrandDTO dto)
        {
            try
            {
                BrandDAL dal = new BrandDAL();
                dal.Delete(MyMapper.BrandDTOToBrand(dto));
                dal.MySaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: MarkaSil");
            }
            return false;
        }

    }
}
