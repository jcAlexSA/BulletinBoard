using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        void Add(T entity);

    }
}
