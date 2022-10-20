using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YesilEvAppYigit.DTO
{
    public class RiskDTO
    {
        public int RiskID { get; set; }
        public string RiskType { get; set; }
        public override string ToString()
        {
            return RiskType;
        }
    }
}
