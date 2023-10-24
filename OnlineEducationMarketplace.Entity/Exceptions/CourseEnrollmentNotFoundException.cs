namespace OnlineEducationMarketplace.Entity.Exceptions
{
    public sealed class CourseEnrollmentNotFoundException : NotFoundException
    {
        public CourseEnrollmentNotFoundException(int courseEnrollmentId) : base($"The course with id : {courseEnrollmentId} could not found.")
        {
        }
    }
}
