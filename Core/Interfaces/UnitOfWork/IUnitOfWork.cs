using Core.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IDataContext DataContext { get; }

        void Save();
    }
}
