using online_school_api.Books.Dtos;

namespace online_school_api.Books.Service
{
    public interface ICommandServiceBook
    {

        Task<BookResponse> CreateBookResponse(BookRequest create);


        Task<BookResponse> DeleteBook(int id);





    }
}
