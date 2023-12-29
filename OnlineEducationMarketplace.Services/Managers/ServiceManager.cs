using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using OnlineEducationMarketplace.Data.Contracts;
using OnlineEducationMarketplace.Entity.Entities;
using OnlineEducationMarketplace.Services.Contracts;
using OnlineEducationMarketplace.Services.Managers;
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
        private readonly Lazy<IAuthenticationService> _authenticationService;
        private readonly Lazy<IReplyService> _replyService;

        public ServiceManager(IRepositoryManager repositoryManager,IMapper mapper, UserManager<User> userManager, IConfiguration configuration) 
        {
            _courseService = new Lazy<ICourseService>(()=> new CourseManager(repositoryManager,mapper));
            _userService = new Lazy<IUserService>(() => new UserManager(repositoryManager, mapper));
            _reviewService = new Lazy<IReviewService>(() => new ReviewManager(repositoryManager, mapper));
            _replyService = new Lazy<IReplyService>(() => new ReplyManager(repositoryManager, mapper));
            _courseEnrollmentService = new Lazy<ICourseEnrollmentService>(() => new CourseEnrollmentManager(repositoryManager, mapper));
            _categoryService = new Lazy<ICategoryService>(() => new CategoryManager(repositoryManager));
            _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationManager(repositoryManager, mapper, userManager, configuration));



        }
        public ICourseService CourseService => _courseService.Value;
        public IUserService UserService => _userService.Value;

        public IReviewService ReviewService => _reviewService.Value;
        public IReplyService ReplyService => _replyService.Value;

        public ICourseEnrollmentService CourseEnrollmentService => _courseEnrollmentService.Value;

        public ICategoryService CategoryService => _categoryService.Value;

        public IAuthenticationService AuthenticationService => _authenticationService.Value;

    }

    
}
