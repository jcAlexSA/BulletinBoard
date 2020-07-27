using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface IAdvertsRepository : IBaseRepository<Advert>
    {
        Advert[] GetAdverts();
    }
}
