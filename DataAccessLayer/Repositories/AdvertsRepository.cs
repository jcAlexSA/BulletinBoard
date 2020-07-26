using Core.Interfaces.Repositories;
using Core.Interfaces.UnitOfWork;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class AdvertsRepository : BaseRepository<Advert>, IAdvertsRepository
    {
        public AdvertsRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
