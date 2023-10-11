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
    public class ReviewRepository : RepositoryBase<Review>, IReviewRepository
    {
        public ReviewRepository(RepositoryContext context) : base(context)
        {
        }

        public IQueryable<Review> GetAllReviews(bool trackChanges) =>
            FindAll(trackChanges).OrderBy(x => x.ReviewId);

        public IQueryable<Review> GetReviewByCourseId(int courseId, bool trackChanges) =>
            FindByCondition(x => x.CourseId.Equals(courseId), trackChanges);

        public IQueryable<Review> GetReviewByUserId(int userId, bool trackChanges) =>
            FindByCondition(x => x.UserId.Equals(userId), trackChanges);

        
        public void CreateReview(Review review) => Create(review);

        public void DeleteReview(Review review) => Delete(review);

        public void UpdateReview(Review review) => Update(review);
    }
}
