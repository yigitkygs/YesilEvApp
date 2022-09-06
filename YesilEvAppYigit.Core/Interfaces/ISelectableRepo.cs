using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YesilEvAppYigit.Core.Interfaces
{
    public interface ISelectableRepo<T> : IRepo<T> where T : class
    {
        List<T> GetAll();
        T GetByID(object ID);
        List<T> GetBy(Func<T, bool> whereCondition);
    }
}
