namespace OnlineEducationMarketplace.Entity.Exceptions
{
    public sealed class CategoryNotFoundException : NotFoundException
    {
        public CategoryNotFoundException(int categoryId) : base($"The course with id : {categoryId} could not found.")
        {
        }
    }
}
