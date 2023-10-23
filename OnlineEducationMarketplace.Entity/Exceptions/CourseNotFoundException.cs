namespace OnlineEducationMarketplace.Entity.Exceptions
{
    public sealed class CourseNotFoundException : NotFoundException 
    {
        public CourseNotFoundException(int courseId) : base($"The course with id : {courseId} could not found.")
        {
        }
    }
}
