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
    public class BlacklistDAL : RepoBase<YesilEvDbContext, Blacklist>
    {
        public List<BlacklistDTO> GetAllBlacklists()
        {
            List<BlacklistDTO> dto = new List<BlacklistDTO>();
            try
            {
                BlacklistDAL dal = new BlacklistDAL();
                dto = MyMapper.ListBlacklistToListBlacklistDTO(dal.GetAll().Where(a => a.IsActive == true).ToList());
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: GetAllBlacklists");
            }
            return dto;
        }
        public List<BlacklistDTO> GetAllBlacklistsAdmin()
        {
            List<BlacklistDTO> dto = new List<BlacklistDTO>();
            try
            {
                BlacklistDAL dal = new BlacklistDAL();
                dto = MyMapper.ListBlacklistToListBlacklistDTO(dal.GetAll());
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: GetAllBlacklistsAdmin");
            }
            return dto;
        }
        public List<BlacklistDTO> GetAllBlacklistsFKWithUserID(int ID)
        {
            List<BlacklistDTO> dto = new List<BlacklistDTO>();
            try
            {
                BlacklistDAL dal = new BlacklistDAL();
                List<Blacklist> temp =null;
                using (YesilEvDbContext db = new YesilEvDbContext())
                {
                    var t1 = db.Blacklists.Join(db.Users,a=>a.UserID,b=>b.UserID,(a,b)=> new
                    {
                        UserID = a.UserID,
                        IsActive = a.IsActive,
                        Date = a.CreateDate,
                        ListID = a.BlacklistID,
                        User= b
                    }).ToList();
                    temp = t1.Select(a => new Blacklist()
                    {
                        UserID = a.UserID,
                        IsActive = a.IsActive,
                        CreateDate= a.Date,
                        BlacklistID = a.ListID,
                        User = a.User
                    }).ToList();
                    temp.ForEach(a => a.BlacklistAllergens=(db.BlacklistAllergens.Where(b => b.BlacklistID == a.BlacklistID).ToList()));
                }
                dto = MyMapper.ListBlacklistToListBlacklistDTO(temp).Where(a=>a.UserID==ID).ToList();
            }

            catch (Exception e)
            {
                Console.WriteLine("Hata: GetAllBlacklists");
            }
            return dto;
        }
        public BlacklistDTO GetBlacklistByID(int ID)
        {
            BlacklistDTO gonderilecek = null;
            try
            {
                gonderilecek = MyMapper.BlacklistToBlacklistDTO(new BlacklistDAL().GetByID(ID));
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: GetBlacklistByID");
            }
            return gonderilecek;
        }
        public List<BlacklistDTO> GetBlacklistFromUserID(object ID)
        {
            List<BlacklistDTO> dto = new List<BlacklistDTO>();
            try
            {
                BlacklistDAL dal = new BlacklistDAL();
                dto = MyMapper.ListBlacklistToListBlacklistDTO(dal.GetBy(a => a.UserID == (int)ID).Where(a => a.IsActive == true).ToList());
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: GetBlacklistFromUserID");
            }
            return dto;
        }
        public bool AddNewBlacklist(BlacklistDTO dto)
        {
            try
            {
                BlacklistDAL dal = new BlacklistDAL();
                dal.Add(MyMapper.BlacklistDTOToBlacklist(dto));
                dal.MySaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: AddNewBlacklist");
            }
            return false;
        }
        public void UpdateBlacklist(BlacklistDTO dto)
        {
            try
            {
                BlacklistDAL dal = new BlacklistDAL();
                dal.Update(MyMapper.BlacklistDTOToBlacklist(dto), dto.UserID);
                dal.MySaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: UpdateBlacklist");
            }
        }
        public void SoftDeleteBlacklist(BlacklistDTO dto)
        {
            try
            {
                BlacklistDAL dal = new BlacklistDAL();
                dto.IsActive = false;
                dal.Update(MyMapper.BlacklistDTOToBlacklist(dto), dto.UserID);
                dal.MySaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: SoftDeleteBlacklist");
            }
        }
        public bool HardDeleteBlacklist(object ID)
        {
            try
            {
                BlacklistDAL dal = new BlacklistDAL();
                dal.Delete(new BlacklistDAL().GetByID(ID));
                dal.MySaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: HardDeleteBlacklist");
            }
            return false;
        }


    }
}
