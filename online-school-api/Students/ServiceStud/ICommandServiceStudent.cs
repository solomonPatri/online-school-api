using online_school_api.Students.Dtos;

namespace online_school_api.Students.ServiceStud
{
    public interface ICommandServiceStudent
    {

        Task<StudentResponse> AddStudentAsync(StudentRequest newstudent);























    }
}
