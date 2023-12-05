using Microsoft.EntityFrameworkCore;
using OnlineEducationMarketplace.Data.Contracts;
using OnlineEducationMarketplace.Data.NewFolder;
using OnlineEducationMarketplace.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationMarketplace.Data.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(RepositoryContext context) : base(context)
        {
        }


        public async Task<IEnumerable<User>> GetAllUsersAsync(bool trackChanges) =>
            await FindAll(trackChanges).OrderBy(x => x.Id).ToListAsync();

        public async Task<User> GetUserByUserIdAsync(int userId, bool trackChanges) =>
            await FindByCondition(x => x.Id.Equals(userId), (trackChanges))
                .SingleOrDefaultAsync();

        public void CreateUser(User user) => Create(user);

        public void UpdateUser(User user) => Update(user);

        public void DeleteUser(User user) => Delete(user);

    }
}
