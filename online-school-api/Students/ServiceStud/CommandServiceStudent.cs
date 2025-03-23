using online_school_api.Students.Dtos;
using online_school_api.Students.Repository;

namespace online_school_api.Students.ServiceStud
{
    public class CommandServiceStudent:ICommandServiceStudent
    {

        private readonly IStudentRepo _repo;

        public CommandServiceStudent(IStudentRepo repo)
        {
            this._repo = repo;



        }


        public async Task<StudentResponse> AddStudentAsync(StudentRequest newstudent)
        {
            StudentResponse exist = await this._repo.FindByName(newstudent.Name);

            if (exist== null)
            {
                StudentResponse response = await _repo.AddStudentAsync(newstudent);

                return response;





            }








        }













    }
}
