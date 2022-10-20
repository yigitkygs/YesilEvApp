using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YesilEvAppYigit.Core;
using YesilEvAppYigit.Core.Repos;
using YesilEvAppYigit.DTO;

namespace YesilEvAppYigit.DAL.Concrete
{
    public class RiskDAL : RepoBase<YesilEvDbContext, Risk>
    {
        public List<RiskDTO> GetAllRisks()
        {
            return new RiskDAL().GetAll().Select(a => new RiskDTO()
            {
                RiskID = a.RiskID,
                RiskType = a.RiskType
            }).ToList();
        }
    }
}
