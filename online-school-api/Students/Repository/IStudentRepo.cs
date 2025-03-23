using online_school_api.Students.Dtos;


namespace online_school_api.Students.Repository
{
    public interface IStudentRepo
    {


        Task<StudentResponse> AddStudentAsync(StudentRequest newstudent);

        Task<GetAllStudentsDto> GetAllStudentAsync();


        













    }
}
