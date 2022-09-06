using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YesilEvAppYigit.Core.Repos;
using YesilEvAppYigit.Core;
using YesilEvAppYigit.DTO;

namespace YesilEvAppYigit.DAL.Concerete
{
    public class BlacklistAllergenDAL : RepoBase<YesilEvDbContext, BlacklistAllergen>
    {
        public List<BlacklistAllergen> TumBlacklistleriGetir()
        {
            List<BlacklistAllergen> dto = new List<BlacklistAllergen>();
            try
            {
                dto = new BlacklistAllergenDAL().GetAll();
            }

            catch (Exception e)
            {
                Console.WriteLine("Hata: TumBlacklistleriGetir");
            }
            return dto;
        }

        public List<BlacklistAllergenDTO> KullaniciBlacklistGetir(int userID)
        {
            List<BlacklistAllergenDTO> dto = new List<BlacklistAllergenDTO>();
            try
            {
                dto = new BlacklistAllergenDAL().GetAll()
                    .Join(new BlacklistDAL()
                    .GetAll(),a=>a.BlacklistID,b=>b.ListID,(a,b)=> new BlacklistAllergenDTO() {
                    ID = a.ID,
                    AllergenID = a.AllergenID,
                    BlacklistID = a.BlacklistID,
                    IsActive = a.IsActive,
                    DateAdded = a.DateAdded,
                    UserID = b.UserID,
                    Blacklist =a.Blacklist,
                    Allergen = a.Allergen
                    
                }).Where(a=>a.UserID==userID).ToList();
            }

            catch (Exception e)
            {
                Console.WriteLine("Hata: TumBlacklistleriGetir");
            }
            return dto;
        }


    }
}
