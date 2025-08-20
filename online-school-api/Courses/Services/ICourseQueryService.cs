using online_school_api.Courses.Dto;

namespace online_school_api.Courses.Services
{
    public interface ICourseQueryService
    {

        Task<GetAllCourseDtos> GetAllCourseAsync();
        Task<CourseResponse?> GetCourseMostPopular();







    }
}
