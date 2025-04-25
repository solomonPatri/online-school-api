using online_school_api.Courses.Dto;
using online_school_api.Courses.Repository;
using online_school_api.Courses.Exceptions;
using System.Diagnostics.SymbolStore;

namespace online_school_api.Courses.Services
{
    public class CourseQueryService:ICourseQueryService
    {

        private readonly ICourseRepo _repo;
        
        public CourseQueryService(ICourseRepo repo)
        {

            this._repo = repo;

        }

        public async Task<GetAllCourseDtos> GetAllCourseAsync()
        {

            GetAllCourseDtos response = await _repo.GetAllCourseAsync();

            if(response != null)
            {

                return response;
            }
            throw new CourseNotFoundException();


        }












    }
}
