using Core.Interfaces.Repositories;
using Core.Interfaces.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        public BaseRepository(IUnitOfWork unitOfWork)
        {
            this.DbContext = unitOfWork.DataContext as DbContext;
        }

        protected DbContext DbContext { get; private set; }


        public void Add(T entity)
        {
            this.DbContext.Set<T>().Add(entity);
        }
    }
}
