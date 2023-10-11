using OnlineEducationMarketplace.Data.Contracts;
using OnlineEducationMarketplace.Data.NewFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationMarketplace.Data.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        public RepositoryManager(RepositoryContext context)
        {
            _context = context;
            
        }
        public IUserRepository User => new UserRepository(_context);
        public ICourseRepository Course => new CourseRepository(_context);

        public IReviewRepository Review => new ReviewRepository(_context);

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
