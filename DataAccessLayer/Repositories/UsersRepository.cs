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
    public class UsersRepository : BaseRepository<User>, IUsersRepository
    {
        public UsersRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public void Add(User user)
        {
            this.DbContext.Set<User>().Add(user);
        }
    }
}
