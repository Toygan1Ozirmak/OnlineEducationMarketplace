using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationMarketplace.Services.Contracts
{
    public interface IServiceManager
    {
        ICourseService CourseService { get; }

        IUserService UserService { get; }

        IReviewService ReviewService { get; }

        ICourseEnrollmentService CourseEnrollmentService { get; }

        ICategoryService CategoryService { get; }

        IAuthenticationService AuthenticationService { get; }
        IReplyService ReplyService { get; }
        

        
    }
}
