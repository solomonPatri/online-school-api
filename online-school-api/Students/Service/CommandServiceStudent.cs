using online_school_api.Students.Dtos;
using online_school_api.Students.Repository;
using online_school_api.Students.Exceptions;
using online_school_api.Students.Model;

namespace online_school_api.Students.Service
{
    public class CommandServiceStudent:ICommandServiceStudent
    {

        private readonly IStudentRepo _repo;

        public CommandServiceStudent(IStudentRepo repo)
        {
            this._repo = repo;



        }




       public async  Task<StudentResponse> CreateAsync(StudentRequest student)
       {


            return await this._repo.CreateStudentAsync(student);




        }



    }
}
