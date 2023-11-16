using AutoMapper;
using OnlineEducationMarketplace.Entity.DTOs;
using OnlineEducationMarketplace.Entity.Entities;

namespace OEMAP.Api.Utilities.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            
            CreateMap<Review, ReviewDto>();
            CreateMap<ReviewDtoForUpdate, Review>();
            CreateMap<ReviewDtoForInsertion, Review>();

            CreateMap<CourseEnrollmentDtoForUpdate, CourseEnrollment>();
            CreateMap<CourseEnrollmentDtoForInsertion, CourseEnrollment>();
            CreateMap<CourseEnrollment, CourseEnrollmentDto>();

            CreateMap<Course, CourseDto>();
            CreateMap<CourseDtoForUpdate, Course>();
            CreateMap<CourseDtoForInsertion, Course>();

            
            CreateMap<User, UserDto>();
            CreateMap<UserDtoForUpdate, User>();
            CreateMap<UserDtoForInsertion, User>();
            CreateMap<UserForRegistrationDto, User>();

        }
    }
}