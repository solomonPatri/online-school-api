using online_school_api.Books.Dtos;
using online_school_api.Students.Dtos;
using online_school_api.Students.Model;

namespace online_school_api.Students.Service
{
    public interface ICommandServiceStudent
    {

        Task<StudentResponse> CreateAsync(StudentRequest studentRequest);

        Task<BookResponse> AddBookAsync(BookRequest bookRequest);



















    }
}
