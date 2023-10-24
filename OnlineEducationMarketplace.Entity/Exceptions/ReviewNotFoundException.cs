namespace OnlineEducationMarketplace.Entity.Exceptions
{
    public sealed class ReviewNotFoundException : NotFoundException
    {
        public ReviewNotFoundException(int reviewId) : base($"The course with id : {reviewId} could not found.")
        {
        }
    }
}
