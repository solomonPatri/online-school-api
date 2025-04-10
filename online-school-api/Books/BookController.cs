using AutoMapper;
using Microsoft.EntityFrameworkCore;
using online_school_api.Books.Dtos;
using online_school_api.Books.Model;
using Microsoft.AspNetCore.Mvc;
using online_school_api.Books.Service;
using online_school_api.Books.Repository;
using online_school_api.Books.Exceptions;

namespace online_school_api.Books
{
    [ApiController]
    [Route("api/v2/[Controller]")]
    public class BookController:ControllerBase
    {

        private readonly ICommandServiceBook _command;

        private readonly IQueryServiceBook _query;

        public BookController(ICommandServiceBook command,IQueryServiceBook query)
        {
            _command = command;
            _query = query;
        }




        [HttpGet("allBooks")]

        public async Task<ActionResult<GetAllBooksDto>> GetAllBooksAsync()
        {
            try
            {
                GetAllBooksDto response = await _query.GetAllBooksAsync();

                return Ok(response);


            }catch(BookNotFoundException nf)
            {
                return NotFound(nf.Message);
            }

        }



        [HttpPost("createBook")]

        public async Task<ActionResult<BookResponse>> CreateBookAsync([FromBody]BookRequest book)
        {

            try
            {
                BookResponse response = await _command.CreateBookResponse(book);

                return Created("", response);


            }catch(BookAlreadyExistException al)
            {
                return BadRequest(al.Message);
            }




        }

        [HttpDelete("DeleteBook/{id}")]

        public async Task<ActionResult<BookResponse>> DeleteBookAsync([FromRoute]int id)
        {
            try
            {
                BookResponse response = await _command.DeleteBook(id);

                return Accepted("", response);


            }catch(BookNotFoundException nf)
            {
                return NotFound(nf.Message);
            }






        }




    }
}
