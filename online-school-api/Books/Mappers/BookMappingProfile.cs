using AutoMapper;
using FluentMigrator.Builder.Create.Index;
using online_school_api.Books.Model;
using online_school_api.Books.Dtos;

namespace online_school_api.Books.Mappers
{
    public class BookMappingProfile:Profile
    {
        public BookMappingProfile()
        {

            CreateMap<BookRequest, Book>();
            CreateMap<Book, BookResponse>();
            CreateMap<Book, BookResponse>();






        }









    }
}
