using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YesilEvAppYigit.Core.Repos;
using YesilEvAppYigit.Core;

namespace YesilEvAppYigit.DAL.Concerete
{
    public class BlacklistDAL : RepoBase<YesilEvDbContext, Blacklist>
    {
        public List<Blacklist> TumBlacklistleriGetir()
        {
            List<Blacklist> dto = new List<Blacklist>();
            try
            {
                dto = new BlacklistDAL().GetAll();
            }

            catch (Exception e)
            {
                Console.WriteLine("Hata: TumBlacklistleriGetir");
            }
            return dto;
        }
    }
}
