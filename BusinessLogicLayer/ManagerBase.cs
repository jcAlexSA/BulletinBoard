using Core.Interfaces.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public abstract class ManagerBase
    {
        protected IUnitOfWork unitOfWork { get; private set; }

        public ManagerBase(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
    }
}