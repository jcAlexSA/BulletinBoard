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

        /// <summary>
        /// Get user entity by email.
        /// </summary>
        /// <param name="email">User email address.s</param>
        /// <returns>User entity.</returns>
        public User GetUserByEmail(string email)
        {
            User user = this.DbContext.Set<User>().Where(u => u.Email.Equals(email))
                .FirstOrDefault();

            return user;
        }
    }
}
