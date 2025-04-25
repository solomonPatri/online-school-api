using AutoMapper;
using Microsoft.EntityFrameworkCore;
using online_school_api.Courses.Dto;
using online_school_api.Courses.Model;
using online_school_api.Data;
using System.Data.Entity;

namespace online_school_api.Courses.Repository
{
    public class CourseRepo:ICourseRepo
    {


        private readonly AppDbContext _context;

        private readonly IMapper _mapper;

        public CourseRepo(AppDbContext context,IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<GetAllCourseDtos> GetAllCourseAsync()
        {
            var courses = await _context.Courses
                .ToListAsync();

            var mapped = _mapper.Map<List<CourseResponse>>(courses);

            return new GetAllCourseDtos
            {

                CourseList = mapped

            };
             




        }

        public async Task<CourseResponse> CreateCourseAsync(CourseRequest create)
        {
            var course = _mapper.Map<Course>(create);

            await _context.Courses.AddAsync(course);

           _context.SaveChangesAsync();

            var response = _mapper.Map<CourseResponse>(course);

            return response;







        }


        public async Task<CourseResponse> FindByNameCourseAsync(string name)
        {
            Course searched = await _context.Courses.FirstOrDefaultAsync(c => c.Name.Equals(name));
            CourseResponse response = _mapper.Map<CourseResponse>(searched);

            return response;



        }








    }
}
