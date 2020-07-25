using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface IUsersRepository : IBaseRepository<User>
    {
        void Add(User user);
    }
}
