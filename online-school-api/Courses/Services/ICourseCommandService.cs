using online_school_api.Courses.Dto;

namespace online_school_api.Courses.Services
{
    public interface ICourseCommandService
    {

        Task<CourseResponse> CreateCourseAsync(CourseRequest create);






    }
}
