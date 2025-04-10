using online_school_api.Books.Dtos;

namespace online_school_api.Books.Repository
{
    public interface IBookRepo
    {

        Task<GetAllBooksDto> GetAllBooksAsync();

        Task<BookResponse> CreateBookResponse(BookRequest create);

        Task<BookResponse> GetByIdAsync(int id);

        Task<BookResponse> FindByIdAsync(int id);

        Task<BookResponse> FindByNameAsync(string nambook);


        Task<BookResponse> DeleteBook(int id);
















    }
}
