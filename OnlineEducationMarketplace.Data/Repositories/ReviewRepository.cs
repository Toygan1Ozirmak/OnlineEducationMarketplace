using Microsoft.EntityFrameworkCore;
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


        public async Task<IEnumerable<Review>> GetReviewsByCourseIdAsync(int courseId, bool trackChanges) =>
            await FindByCondition(x => x.CourseId.Equals(courseId), trackChanges).ToListAsync();

        public async Task<Review> GetReviewByReviewIdAsync(int reviewId, bool trackChanges) =>
             await FindByCondition(x => x.ReviewId.Equals(reviewId), trackChanges)
                .SingleOrDefaultAsync();


        public void CreateReview(Review review) => Create(review);

        public void DeleteReview(Review review) => Delete(review);

        public void UpdateReview(Review review) => Update(review);
    }
}
