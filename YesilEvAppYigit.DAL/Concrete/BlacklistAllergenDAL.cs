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
    public class BlacklistAllergenDAL : RepoBase<YesilEvDbContext, BlacklistAllergen>
    {
        public List<BlacklistAllergenDTO> GetAllBlacklistAllergens()
        {
            List<BlacklistAllergenDTO> dto = new List<BlacklistAllergenDTO>();
            try
            {
                dto = MyMapper.ListBlacklistAllergenToListBlacklistAllergenDTO(new BlacklistAllergenDAL().GetAll());
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: GetAllBlacklistAllergens");
            }
            return dto;
        }
        public List<BlacklistAllergenDTO> GetAllBlacklistAllergensFromUserID(int ID)
        {
            List<BlacklistAllergenDTO> dto = new List<BlacklistAllergenDTO>();
            try
            {
                dto = new BlacklistAllergenDAL().GetAll()
                    .Join(new BlacklistDAL()
                    .GetAll(), a => a.BlacklistID, b => b.BlacklistID, (a, b) => new BlacklistAllergenDTO()
                    {
                        BlacklistAllergenID = a.BlacklistAllergenID,
                        AllergenID = a.AllergenID,
                        BlacklistID = a.BlacklistID,
                        IsActive = a.IsActive,
                        CreateDate = a.CreateDate,
                        UserID = b.UserID,
                        Blacklist = a.Blacklist,
                        Allergen = a.Allergen

                    }).Where(a => a.UserID == ID).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: GetAllBlacklistAllergensFromUserID");
            }
            return dto;
        }
        public BlacklistAllergenDTO GetBlacklistAllergenFromID(object ID)
        {
            BlacklistAllergenDTO gonderilecek = new BlacklistAllergenDTO();
            try
            {
                gonderilecek = MyMapper.BlacklistAllergenToBlacklistAllergenDTO(new BlacklistAllergenDAL().GetByID(ID));
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: GetBlacklistAllergenFromID");
            }
            return gonderilecek;
        }
        public bool AddNewBlacklistAllergen(BlacklistAllergenDTO dto)
        {
            try
            {
                BlacklistAllergenDAL dal = new BlacklistAllergenDAL();
                dal.Add(MyMapper.BlacklistAllergenDTOToBlacklistAllergen(dto));
                dal.MySaveChanges();
                return true;
            }

            catch (Exception e)
            {
                Console.WriteLine("Hata: AddNewBlacklistAllergen");
            }
            return false;
        }
        public void UpdateBlacklistAllergen(BlacklistAllergenDTO dto)
        {
            try
            {
                BlacklistAllergenDAL dal = new BlacklistAllergenDAL();
                dal.Update(MyMapper.BlacklistAllergenDTOToBlacklistAllergen(dto));
                dal.MySaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: UpdateBlacklistAllergen");
            }
        }
        public void SoftDeleteBlacklistAllergen(BlacklistAllergenDTO dto)
        {
            try
            {
                BlacklistAllergenDAL dal = new BlacklistAllergenDAL();
                dto.IsActive = false;
                dal.Update(MyMapper.BlacklistAllergenDTOToBlacklistAllergen(dto));
                dal.MySaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: SoftDeleteBlacklistAllergen");
            }
        }
        public void RevertSoftDeleteBlacklistAllergen(BlacklistAllergenDTO dto)
        {
            try
            {
                BlacklistAllergenDAL dal = new BlacklistAllergenDAL();
                dto.IsActive = true;
                dal.Update(MyMapper.BlacklistAllergenDTOToBlacklistAllergen(dto));
                dal.MySaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: RevertSoftDeleteBlacklistAllergen");
            }
        }
        public bool HardDeleteBlacklistAllergen(BlacklistAllergenDTO dto)
        {
            try
            {
                BlacklistAllergenDAL dal = new BlacklistAllergenDAL();
                dal.Delete(MyMapper.BlacklistAllergenDTOToBlacklistAllergen(dto));
                dal.MySaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: HardDeleteBlacklistAllergen");
            }
            return false;
        }
    }
}
