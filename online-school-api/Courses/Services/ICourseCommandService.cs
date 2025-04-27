using online_school_api.Courses.Dto;
using online_school_api.Enrolments.Dto;

namespace online_school_api.Courses.Services
{
    public interface ICourseCommandService
    {

        Task<CourseResponse> CreateCourseAsync(CourseRequest create);

        




    }
}
