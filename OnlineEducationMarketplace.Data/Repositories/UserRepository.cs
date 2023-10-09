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

        public void CreateUser(User user) => Create(user);

        public void DeleteUser(User user) => Delete(user);

        public IQueryable<User> GetAllUsers(bool trackChanges) => 
            FindAll(trackChanges).OrderBy(x => x.UserId);

        public IQueryable<User> GetOneUserById(int id, bool trackChanges) =>
            FindByCondition( x => x.UserId.Equals(id),(trackChanges));

        public void UpdateUser(User user) => Update(user);
    }
}
