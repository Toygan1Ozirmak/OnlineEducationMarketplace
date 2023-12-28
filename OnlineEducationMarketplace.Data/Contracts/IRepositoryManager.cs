using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationMarketplace.Data.Contracts
{
    public interface IRepositoryManager
    {
        IUserRepository User { get; }

        ICourseRepository Course { get; }
        IReviewRepository Review { get; }

        ICategoryRepository Category { get; }

        ICourseEnrollmentRepository CourseEnrollment { get; }
        IReplyRepository Reply { get; }



        Task SaveAsync();
    }
}
