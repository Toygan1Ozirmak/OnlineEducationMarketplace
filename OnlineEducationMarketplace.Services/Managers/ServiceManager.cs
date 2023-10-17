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
        public ServiceManager(IRepositoryManager repositoryManager) 
        {
            _courseService = new Lazy<ICourseService>(()=> new CourseManager(repositoryManager));
            
        }
        public ICourseService CourseService => _courseService.Value;

        private readonly Lazy<IUserService> _userService;
        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _userService = new Lazy<IUserService>(() => new UserManager(repositoryManager));

        }
        public IUserService UserService => _userService.Value;

        private readonly Lazy<IReviewService> _reviewService;
        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _reviewService = new Lazy<IReviewService>(() => new ReviewManager(repositoryManager));

        }
        public IReviewService ReviewService => _reviewService.Value;

        private readonly Lazy<ICourseEnrollmentService> _courseEnrollmentService;
        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _courseEnrollmentService = new Lazy<ICourseEnrollmentService>(() => new CourseEnrollmentManager(repositoryManager));

        }
        public ICourseEnrollmentService CourseEnrollmentService => _courseEnrollmentService.Value;
    }

    private readonly Lazy<ICategoryService> _categoryService;
    public ServiceManager(IRepositoryManager repositoryManager)
    {
        _categoryService = new Lazy<ICategoryService>(() => new CategoryManager(repositoryManager));

    }
    public ICategoryService CategoryService => _categoryService.Value;

    private readonly Lazy<IPaymentService> _paymentService;
    public ServiceManager(IRepositoryManager repositoryManager)
    {
        _paymentService = new Lazy<IPaymentService>(() => new PaymentManager(repositoryManager));

    }
    public IPaymentService PaymentService => _paymentService.Value;
}
