using AutoMapper;
using OnlineEducationMarketplace.Entity.DTOs;
using OnlineEducationMarketplace.Entity.Entities;

namespace OEMAP.Api.Utilities.AutoMapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CourseDtoForUpdate, Course>();
            CreateMap<UserDtoForUpdate, User>();
            CreateMap<ReviewDtoForUpdate, Review>();
            CreateMap<CourseEnrollmentDtoForUpdate, CourseEnrollment>();
                
        }
    }
}
