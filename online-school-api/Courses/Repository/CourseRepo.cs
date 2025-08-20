using AutoMapper;
using Microsoft.EntityFrameworkCore;
using online_school_api.Data;
using online_school_api.Courses.Dto;
using online_school_api.Courses.Mappers;
using online_school_api.Courses.Model;

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
            var courses = await _context.Courses.Include(c=>c.Enrolments).ToListAsync();

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

           await _context.SaveChangesAsync();

            var response = _mapper.Map<CourseResponse>(course);

            return response;


        }

        public async Task<CourseResponse> FindByIdAsync(int id)
        {
            Course course = await _context.Courses.FindAsync(id);
            return _mapper.Map<CourseResponse>(course);




        }
        public async Task<CourseResponse> FindByNameCourseAsync(string name)
        {
            Course searched = await _context.Courses.FirstOrDefaultAsync(c => c.Name.Equals(name));
            CourseResponse response = _mapper.Map<CourseResponse>(searched);

            return response;



        }

        public async Task<Course?> GetEntityByIdAsync(int id)
        {

            return await _context.Courses.Include(c => c.Enrolments).FirstOrDefaultAsync(e => e.Id == id);



        }

       
        public async Task UpdateAsync(Course course)
        {

            _context.Courses.Update(course);

            await _context.SaveChangesAsync();
        }


        public async Task<CourseResponse> DeleteCourseAsync(int id)
        {

            Course course = await _context.Courses.FindAsync(id);

            CourseResponse response = _mapper.Map<CourseResponse>(course);
            _context.Remove(course);

            await _context.SaveChangesAsync();

            return response;


        }

        public async Task<CourseResponse?> GetCourseMostPopular()
        {
            var course = await _context.Courses.Include(c => c.Enrolments)
                .OrderByDescending(c => c.Enrolments.Count)
                .FirstOrDefaultAsync();

            return course == null ? null : _mapper.Map<CourseResponse>(course);

           
        }


        public async Task<CourseResponse> UpdateCourseAsync(int id, CourseUpdateRequest update)
        {
            Course ex = await _context.Courses.FindAsync(id);

            if (update.Name != null)
            {
                ex.Name = update.Name;

            }

            if (update.Departament != null)
            {

                ex.Departament = update.Departament;

            }

            _context.Courses.Update(ex);

            await _context.SaveChangesAsync();

            CourseResponse response = _mapper.Map<CourseResponse>(ex);

            return response;





        }




    }
}
