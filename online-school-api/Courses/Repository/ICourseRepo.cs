using online_school_api.Courses.Dto;
using Microsoft.EntityFrameworkCore;
using online_school_api.Courses.Model;

namespace online_school_api.Courses.Repository
{
    public interface ICourseRepo
    {


        Task<GetAllCourseDtos> GetAllCourseAsync();

        Task<CourseResponse> CreateCourseAsync(CourseRequest create);


        Task<CourseResponse> FindByNameCourseAsync(string name);

        Task<Course?> GetEntityByIdAsync(int id);


        Task<CourseResponse> UpdateCoursAsync(int id, CourseUpdateRequest update);

        Task UpdateAsync(Course course);


    }
}
