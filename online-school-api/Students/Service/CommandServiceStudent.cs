using AutoMapper;
using online_school_api.Books.Dtos;
using online_school_api.Books.Model;
using online_school_api.Students.Dtos;
using online_school_api.Students.Repository;
using online_school_api.Students.Exceptions;
using online_school_api.Students.Model;

namespace online_school_api.Students.Service
{
    public class CommandServiceStudent:ICommandServiceStudent
    {

        private readonly IStudentRepo _repo;
        private readonly IMapper _mapper;

        public CommandServiceStudent(IStudentRepo repo, IMapper mapper)
        {
            this._repo = repo;
            this._mapper = mapper;


        }




       public async  Task<StudentResponse> CreateAsync(StudentRequest student)
       {
           return await this._repo.CreateStudentAsync(student);

       }
       public async Task<BookResponse> AddBookAsync(BookRequest bookRequest)
       {
           var student = await _repo.GetEntityByIdAsync(bookRequest.StudentId);

           if (student == null)
               throw new StudentNotFoundException();

           var book = _mapper.Map<Book>(bookRequest);
           book.Created = DateTime.UtcNow;

           student.Books.Add(book);

           await _repo.UpdateAsync(student);

           return _mapper.Map<BookResponse>(book);
       }




    }
}
