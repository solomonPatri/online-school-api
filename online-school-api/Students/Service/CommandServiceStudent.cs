using AutoMapper;
using online_school_api.Books.Dtos;
using online_school_api.Books.Model;
using online_school_api.Students.Dtos;
using online_school_api.Students.Repository;
using online_school_api.Students.Exceptions;
using online_school_api.Students.Model;
using Microsoft.AspNetCore.Server.IIS.Core;
using online_school_api.Books.Exceptions;
using System.CodeDom;
using Microsoft.AspNetCore.Http.HttpResults;
using online_school_api.Enrolments.Dto;
using online_school_api.Courses.Exceptions;
using online_school_api.Enrolments.Model;
using online_school_api.Enrolments.Mappers;
using System.Runtime.InteropServices;
using online_school_api.Enrolments.Exceptions;
using Microsoft.JSInterop;

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
            StudentResponse verif = await this._repo.FindByNameStudentAsync(student.Name);

            if(verif== null)
            {
                StudentResponse response = await this._repo.CreateStudentAsync(student);

                return response;
            }
            throw new StudentAlreadyExistExcept();


       }
       public async Task<BookResponse> AddBookAsync(BookRequest bookRequest)
       {
           var student = await _repo.GetEntityByIdAsync(bookRequest.StudentId);
           
           if (student != null)
            {
                var b = _mapper.Map<Book>(bookRequest);
                var book = await _repo.GetBookByStudentIdAsync(bookRequest.Name, student.Id);

                if (book == null)
                {
                    b.Created = DateTime.UtcNow;

                    student.Books.Add(b);

                    await _repo.UpdateAsync(student);

                    return _mapper.Map<BookResponse>(b);
                }
                throw new BookAlreadyExistException();
            }
               throw new StudentNotFoundException();

          

       }
      

        public async Task<StudentResponse> UpdateStudentAsync(int id,StudentUpdateRequest update)
        {

            StudentResponse verf = await this._repo.FindByIdAsync(id);

            if(verf != null)
            {
                if(verf is StudentRequest)
                {

                    verf.Name = update.Name ?? verf.Name;
                    verf.Email = update.Email ?? verf.Email;
                    verf.Age = update.Age ?? verf.Age;
                    verf.University = update.University ??verf.University;

                    StudentResponse response = await this._repo.UpdateAsync(id, update);

                    return response;


                }
               


            }
            throw new StudentNotFoundException();



        }

        public async Task<StudentResponse> DeleteStudentAsync(int id)
        {
            StudentResponse vef = await _repo.FindByIdAsync(id);

            if(vef != null)
            {

                StudentResponse response = await _repo.DeleteStudentAsync(id);

                return response;

            }
            throw new StudentNotFoundException();






        }


       public async  Task<BookResponse> DeleteBookAsync(int idstudent,int idBook)
        {
            Student student = await _repo.GetEntityByIdAsync(idstudent);
            Book book = student.Books.FirstOrDefault(s => s.Id == (idBook));

            if (student != null)
            {
                if (book != null)
                {

                    BookResponse response = await _repo.DeleteBookAsync(idstudent, idBook);

                    return response;


                }

                throw new BookNotFoundException();

            }

            throw new StudentNotFoundException();


        }


      public async Task<BookResponse> UpdateBookAsync(int idstudent, int idbook, BookUpdateRequest updatebook)
            {

                Student stud = await _repo.GetEntityByIdAsync(idstudent);

                Book book = stud.Books.First(b => b.Id == idbook);

                if (book != null)
                {

                    return await _repo.UpdateBookAsync(idstudent, idbook, updatebook); 

                }
                throw new BookNotFoundException();

            }


        public async Task<EnrolmentResponse> AddEnrolment(EnrolmentRequest create)
        {
            var student = await _repo.GetEntityByIdAsync(create.StudentId);
          

            if (student != null)
            {
                var enr = _mapper.Map<Enrolment>(create);
                var course = await _repo.GetEnrolledCourseByStudentIdAsync(create.CourseId, student.Id);
                if (course==null)
                {

                    enr.Created = DateTime.UtcNow;

                    student.Enrolments.Add(enr);

                    await _repo.UpdateAsync(student);
                    return _mapper.Map<EnrolmentResponse>(enr);

                }
                throw new CourseAlreadyExistException();
            }
               throw new StudentNotFoundException();
        }


        // public async  Task<EnrolmentResponse> UpdateEnrolmentAsync(int idstudent, EnrolmentUpdateRequest update)
        // {


        //     Student stud = await _repo.GetEntityByIdAsync(idstudent);

        //     var response = stud.Enrolments.First(e => e.CourseId == update.courseId);
        //
        //     if (response != null)
        ///      {

        ///        return await _repo.UpdateEnrolmentAsync(idstudent, update);

        //   }
        //   throw new EnrolmentsNotFoundException();



        // }


       public async  Task<EnrolmentResponse> UpdateEnrolmentAsync(int studentid, int oldidcourse, int newidcourse)
        {
            GetAllEnroments list = await _repo.GetAllEnrolmentsByStudentId(studentid);


           var  select = list.EnrolmentList.Where(s => s.CourseId == oldidcourse);

            Enrolment response = _mapper.Map<Enrolment>(select);

            if(response != null)
            {

                EnrolmentResponse res = await _repo.UpdateEnrolmentsAsync(studentid, oldidcourse, newidcourse);
                return res;
            
            }
            throw new EnrolmentsNotFoundException();




        }






    }
}
