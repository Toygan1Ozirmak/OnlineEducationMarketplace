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

        public void CreateReview(Review review) => Create(review);

        public void DeleteReview(Review review) => Delete(review);

        public IQueryable<User> GetReviewByCourseId(int id, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public void UpdateReview(Review review) => Update(review);
    }
}
