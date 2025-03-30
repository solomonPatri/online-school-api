using online_school_api.Students.Dtos;
using online_school_api.Students.Exceptions;
using online_school_api.Students.Model;


namespace online_school_api.Students.Repository
{
    public interface IStudentRepo
    {

        Task<GetAllStudentsDto> GetAllAsync();


        Task<StudentResponse> CreateStudentAsync(StudentRequest studentRequest);


        Task<StudentResponse> GetByIdAsync(int id);
   
        Task<Student?> GetEntityByIdAsync(int id);

        Task<StudentResponse> UpdateAsync(int id, StudentUpdateRequest update);


        Task<StudentResponse> FindByNameStudentAsync(string name);

        Task<StudentResponse> FindByIdAsync(int id);
        Task UpdateAsync(Student student);


        Task<StudentResponse> DeleteStudentAsync(int id);

        Task<DeleteBookRequest> DeleteBookAsync(int idstudent, int idBook);








    }
}
