namespace OnlineEducationMarketplace.Entity.Exceptions
{
    public sealed class UserNotFoundException : NotFoundException
    {
        public UserNotFoundException(int userId) : base($"The course with id : {userId} could not found.")
        {
        }
    }
}
