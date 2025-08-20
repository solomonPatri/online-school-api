using AutoMapper;
using Microsoft.EntityFrameworkCore;
using online_school_api.Courses.Dto;
using online_school_api.Courses.Repository;
using online_school_api.Courses.Exceptions;
using online_school_api.Enrolments.Dto;
using online_school_api.Enrolments.Model;

namespace online_school_api.Courses.Services
{
    public class CourseCommandService:ICourseCommandService
    {
        private readonly ICourseRepo _repo;

        private readonly IMapper _mapper;

        public CourseCommandService(ICourseRepo repo, IMapper mapper)
        {
            this._repo = repo;
            this._mapper = mapper;



        }


        public async Task<CourseResponse> CreateCourseAsync(CourseRequest create)
        {
            CourseResponse verf = await this._repo.FindByNameCourseAsync(create.Name);
            if(verf == null)
            {
                CourseResponse response = await this._repo.CreateCourseAsync(create);

                return response;
            }

            throw new CourseNotFoundException();



        }
        public async Task<CourseResponse> DeleteCourseAsync(int id)
        {
            CourseResponse verf = await _repo.FindByIdAsync(id);
            if (verf != null)
            {
                CourseResponse response = await _repo.DeleteCourseAsync(id);
                return response;
            }
            throw new CourseNotFoundException();




        }
        public async Task<CourseResponse> UpdateCourseAsync(int id, CourseUpdateRequest update)
        {

            CourseResponse verif = await this._repo.FindByIdAsync(id);

            if (verif != null)
            {

               
                    verif.Name = update.Name ?? verif.Name;
                    verif.Departament = update.Departament ?? verif.Departament;

                    CourseResponse response = await this._repo.UpdateCourseAsync(id, update);
                    return response;


         

            }

            throw new CourseNotFoundException();
                
                
        }











    }
}
