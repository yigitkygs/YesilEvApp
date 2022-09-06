using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YesilEvAppYigit.Core.Interfaces
{
    public interface IInsertableRepo<T> : IRepo<T> where T : class
    {
        T Add(T item);
        List<T> AddRange(List<T> items);
    }
}
