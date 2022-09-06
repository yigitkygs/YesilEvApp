using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YesilEvAppYigit.Core.Interfaces
{
    public interface IUpdatableRepo<T> : IRepo<T> where T : class
    {
        void Update(T item);
    }
}
