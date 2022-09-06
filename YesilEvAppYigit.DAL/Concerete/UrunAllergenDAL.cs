using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YesilEvAppYigit.Core;
using YesilEvAppYigit.Core.Repos;
using YesilEvAppYigit.DTO;

namespace YesilEvAppYigit.DAL.Concerete
{
    public class UrunAllergenDAL : RepoBase<YesilEvDbContext, UrunAllergen>
    {
        public AllergenDTO getAllergen(int ID)
        {
            return new AllergenDAL().AlerjenGetir(ID);
        }
    }
}
