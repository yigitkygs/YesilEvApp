using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YesilEvAppYigit.Core.Interfaces
{
    public interface IDeletableRepo<T> : IRepo<T> where T : class
    {
        T Delete(T item);
    }
}
