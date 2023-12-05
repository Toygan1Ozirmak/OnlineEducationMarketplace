using AutoMapper;
using OnlineEducationMarketplace.Entity.DTOs;
using OnlineEducationMarketplace.Entity.Entities;

namespace OEMAP.Api.Utilities.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ReviewDtoForUpdate, Review>().ReverseMap();
            CreateMap<Review, ReviewDto>();
            CreateMap<ReviewDtoForUpdate, Review>();
            CreateMap<ReviewDtoForInsertion, Review>();

            CreateMap<CourseEnrollmentDtoForUpdate, CourseEnrollment>().ReverseMap();
            CreateMap<CourseEnrollmentDtoForUpdate, CourseEnrollment>();
            CreateMap<CourseEnrollmentDtoForInsertion, CourseEnrollment>();
            CreateMap<CourseEnrollment, CourseEnrollmentDto>();

            CreateMap<CourseDtoForUpdate, Course>().ReverseMap();
            CreateMap<Course, CourseDto>();
            CreateMap<CourseDtoForUpdate, Course>();
            CreateMap<CourseDtoForInsertion, Course>();


            CreateMap<UserDtoForUpdate, User>().ReverseMap();
            CreateMap<User, UserDto>();
            CreateMap<UserDtoForUpdate, User>();
            CreateMap<UserDtoForInsertion, User>();
            CreateMap<UserForRegistrationDto, User>();

        }
    }
}