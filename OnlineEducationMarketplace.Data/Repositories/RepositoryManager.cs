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
        private readonly Lazy<IUserRepository> _userRepository;
        private readonly Lazy<ICourseRepository> _courseRepository;
        private readonly Lazy<IReviewRepository> _reviewRepository;
        private readonly Lazy<ICategoryRepository> _categoryRepository;
        private readonly Lazy<ICourseEnrollmentRepository> _courseEnrollmentRepository;
        
        public RepositoryManager(RepositoryContext context)
        {
            _context = context;
            _userRepository = new Lazy<IUserRepository>(() => new UserRepository(_context));
            _courseRepository = new Lazy<ICourseRepository>(() => new CourseRepository(_context));
            _reviewRepository = new Lazy<IReviewRepository>(() => new ReviewRepository(_context));
            _categoryRepository = new Lazy<ICategoryRepository>(() => new CategoryRepository(_context));
            _courseEnrollmentRepository = new Lazy<ICourseEnrollmentRepository>(() => new CourseEnrollmentRepository(_context));
            

        }
        public IUserRepository User => _userRepository.Value;

        public ICourseRepository Course => _courseRepository.Value;

        public IReviewRepository Review => _reviewRepository.Value;

        public ICategoryRepository Category => _categoryRepository.Value;

        public ICourseEnrollmentRepository CourseEnrollment=> _courseEnrollmentRepository.Value;



        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
