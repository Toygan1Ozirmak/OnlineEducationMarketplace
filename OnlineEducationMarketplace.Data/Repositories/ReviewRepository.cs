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
    public class ReviewRepository : RepositoryBase<Review>, IReviewRepository//BURDA YAPILACAKLAR VAR
    {
        public ReviewRepository(RepositoryContext context) : base(context)
        {
        }

        public IQueryable<Review> GetAllReviews(bool trackChanges) =>
            FindAll(trackChanges).OrderBy(x => x.ReviewId);

        public Review GetReviewByCourseId(int courseId, bool trackChanges) =>
            FindByCondition(x => x.CourseId.Equals(courseId), trackChanges)
                .SingleOrDefault();

        
        public void CreateReview(Review review) => Create(review);

        public void DeleteReview(Review review) => Delete(review);

        public void UpdateReview(Review review) => Update(review);
    }
}
