using OnlineEducationMarketplace.Data.Contracts;
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
    }
}
