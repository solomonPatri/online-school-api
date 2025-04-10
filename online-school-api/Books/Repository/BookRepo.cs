using AutoMapper;
using Microsoft.EntityFrameworkCore;
using online_school_api.Books.Dtos;
using online_school_api.Books.Model;
using online_school_api.Data;

namespace online_school_api.Books.Repository
{
    public class BookRepo:IBookRepo
    {
        private readonly AppDbContext _context;

        private readonly IMapper _mapper;


        public BookRepo(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;


        }


        public async Task<GetAllBooksDto> GetAllBooksAsync()
        {

             var books = await _context.Books.ToListAsync();
            var map = _mapper.Map<List<BookResponse>>(books);

            return new GetAllBooksDto
            {
                bookslist = map

            };
        
        }


      public async   Task<BookResponse> CreateBookResponse(BookRequest create)
        {

            var searched = _mapper.Map<Book>(create);

             _context.Books.Add(searched);
            await _context.SaveChangesAsync();

            BookResponse response = _mapper.Map<BookResponse>(searched);

            return response;


        }
        public async Task<BookResponse> GetByIdAsync(int id)
        {
            var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == id);

            return _mapper.Map<BookResponse>(book);


        }

        public async Task<BookResponse> FindByNameAsync(string nambook)
        {
            var book = await _context.Books.FirstOrDefaultAsync(b => b.Name.Equals(nambook));

            return _mapper.Map<BookResponse>(book);


        }
        public async Task<BookResponse> FindByIdAsync(int id)
        {
            Book book = await _context.Books.FindAsync(id);

            return _mapper.Map<BookResponse>(book);




        }
        public async Task<BookResponse> DeleteBook(int id)
        {
            Book book = await _context.Books.FindAsync(id);
            if (book != null) {

                _context.Books.Remove(book);
            }
            _context.SaveChangesAsync();

            return _mapper.Map<BookResponse>(book);






        }










    }
}
