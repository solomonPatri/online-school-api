using AutoMapper;
using Microsoft.EntityFrameworkCore;
using online_school_api.Data;
using online_school_api.Students.Dtos;
using online_school_api.Students.Exceptions;
using online_school_api.Students.Model;

namespace online_school_api.Students.Repository
{
    public class StudentRepo : IStudentRepo
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public StudentRepo(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetAllStudentsDto> GetAllAsync()
        {
            var students = await _context.Students
                .Include(s => s.Books)
                .ToListAsync();

            var mapped = _mapper.Map<List<StudentResponse>>(students);

            return new GetAllStudentsDto
            {
                ListStudent = mapped
            };
        }

        public async Task<StudentResponse> CreateStudentAsync(StudentRequest studentRequest)
        {
            var existing = await _context.Students
                .FirstOrDefaultAsync(s => s.Name == studentRequest.Name);

            if (existing != null)
                throw new StudentAlreadyExistExcept();

            var studentEntity = _mapper.Map<Student>(studentRequest);

            await _context.Students.AddAsync(studentEntity);
            await _context.SaveChangesAsync();

            var studentResponse = _mapper.Map<StudentResponse>(studentEntity);

            return studentResponse;
        }
    }
}