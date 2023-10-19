using OnlineEducationMarketplace.Data.Contracts;
using OnlineEducationMarketplace.Entity.Entities;
using OnlineEducationMarketplace.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationMarketplace.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<ICourseService> _courseService;
        private readonly Lazy<IUserService> _userService;
        private readonly Lazy<IReviewService> _reviewService;
        private readonly Lazy<ICourseEnrollmentService> _courseEnrollmentService;
        private readonly Lazy<ICategoryService> _categoryService;
        private readonly Lazy<IPaymentService> _paymentService;
        public ServiceManager(IRepositoryManager repositoryManager) 
        {
            _courseService = new Lazy<ICourseService>(()=> new CourseManager(repositoryManager));
            _userService = new Lazy<IUserService>(() => new UserManager(repositoryManager));
            _reviewService = new Lazy<IReviewService>(() => new ReviewManager(repositoryManager));
            _courseEnrollmentService = new Lazy<ICourseEnrollmentService>(() => new CourseEnrollmentManager(repositoryManager));
            _categoryService = new Lazy<ICategoryService>(() => new CategoryManager(repositoryManager));
            _paymentService = new Lazy<IPaymentService>(() => new PaymentManager(repositoryManager));

        }
        public ICourseService CourseService => _courseService.Value;
        public IUserService UserService => _userService.Value;

        public IReviewService ReviewService => _reviewService.Value;

        public ICourseEnrollmentService CourseEnrollmentService => _courseEnrollmentService.Value;

        public ICategoryService CategoryService => _categoryService.Value;
        public IPaymentService PaymentService => _paymentService.Value;
    }

    
}
