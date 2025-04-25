using AutoMapper;
using online_school_api.Courses.Model;
using online_school_api.Courses.Dto;
using System.Collections.Generic;

namespace online_school_api.Courses.Mappers
{
    public class CourseMappingProfile:Profile
    {
        public CourseMappingProfile()
        {
            CreateMap<CourseRequest, Course>();
            CreateMap<Course, CourseResponse>();
            CreateMap<CourseUpdateRequest, Course>();
            

            CreateMap<Course, CourseResponse>()
                .ForMember(dest => dest.Enrolments, opt => opt.MapFrom(src => src.Enrolments));



        }






    }
}
