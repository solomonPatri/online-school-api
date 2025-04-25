using online_school_api.Courses.Dto;


namespace online_school_api.Courses.Repository
{
    public interface ICourseRepo
    {


        Task<GetAllCourseDtos> GetAllCourseAsync();

        Task<CourseResponse> CreateCourseAsync(CourseRequest create);


        Task<CourseResponse> FindByNameCourseAsync(string name);







    }
}
