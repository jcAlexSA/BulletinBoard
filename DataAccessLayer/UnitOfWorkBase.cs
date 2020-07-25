using Core.DataContext;
using Core.Interfaces.UnitOfWork;
using System;
using System.Data.Entity;

namespace DataAccessLayer
{
    public abstract class UnitOfWorkBase : IUnitOfWork
    {
        private DbContext dbContext;

        private bool disposed;

        public UnitOfWorkBase(IDataContext dataContext)
        {
            this.dbContext = dataContext as DbContext;
        }

        public IDataContext DataContext
        {
            get
            {
                return (IDataContext)this.dbContext;
            }
        }

        public void Save()
        {
            this.dbContext.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.dbContext.Dispose();
                }

                this.disposed = true;
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}