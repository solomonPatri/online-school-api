using online_school_api.Books.Model;
using online_school_api.Students.Repository;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace online_school_api.Students.Dtos
{
    public class StudentResponse
    {
        public int Id { get; set; }

        public string Email { get; set; }



        public string Name { get; set; }

        public int Age { get; set; }

        public string University { get; set; }


        public virtual List<Book> Books { get; set; } = new();




    }
}
