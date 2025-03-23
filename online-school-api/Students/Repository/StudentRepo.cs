using AutoMapper;
using online_school_api.Data;
using online_school_api.Students.Dtos;
using System.Reflection;
using online_school_api.Students.Model;
using System.Data.Entity;

namespace online_school_api.Students.Repository
{
    public class StudentRepo : IStudentRepo
    {

        private readonly AppDbContext _appdbcontextstudent;

        private readonly IMapper _mapper;


        public StudentRepo(AppDbContext appstudent,IMapper mapper)
        {
            this._appdbcontextstudent = appstudent;
            this._mapper = mapper;



        }


        public async   Task<StudentResponse> AddStudentAsync(StudentRequest newstudent)
        {
            Student student = _mapper.Map<Student>(newstudent);

            _appdbcontextstudent.Add(student);

            await _appdbcontextstudent.SaveChangesAsync();

            StudentResponse response = _mapper.Map<StudentResponse>(student);

            return response;






        }

        public async Task<GetAllStudentsDto> GetAllStudentAsync()
        {

           IList<Student> students = await _appdbcontextstudent.Students.ToListAsync();

            var list = students.Select(m => _mapper.Map<StudentResponse>(m)).ToList();

            GetAllStudentsDto response = new GetAllStudentsDto();

            response.ListStudent = list;

            return response;

        }

        public async Task<StudentResponse> FindByName(string name)
        {

            Student student = await _appdbcontextstudent.Students.FirstOrDefaultAsync(m => m.Name.Equals(name));

            StudentResponse response = _mapper.Map<StudentResponse>(student);
            return response;










        }
        


































    }
}
