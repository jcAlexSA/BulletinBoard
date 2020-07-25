using Core.DataContext;
using Core.Interfaces.UnitOfWork;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UnitOfWork : UnitOfWorkBase, IUnitOfWork
    {
        public UnitOfWork(IDataContext dataContext) : base(dataContext)
        {
        }

    }
}
