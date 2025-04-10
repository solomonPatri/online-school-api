using AutoMapper;
using online_school_api.Books.Dtos;
using online_school_api.Books.Repository;
using online_school_api.Books.Exceptions;
namespace online_school_api.Books.Service
{
    public class CommandServiceBook:ICommandServiceBook
    {
        private readonly IBookRepo _repo;
        private readonly IMapper _mapper;

        public CommandServiceBook(IBookRepo repo, IMapper mapper)
        {

            _repo = repo;
            _mapper = mapper;


        }



       public async  Task<BookResponse> CreateBookResponse(BookRequest create)
        {
            BookResponse verf = await _repo.FindByNameAsync(create.Name);

            if (verf == null)
            {
                BookResponse response = await _repo.CreateBookResponse(create);

                return response;


            }
            throw new BookAlreadyExistException();




        }

        public async  Task<BookResponse> DeleteBook(int id)
        {
            BookResponse book = await _repo.FindByIdAsync(id);

            if (book != null)
            {

                BookResponse response = await _repo.DeleteBook(id);

                return response;



            }
            throw new BookNotFoundException();


        }



    }
}
