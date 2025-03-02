using online_school_api;
using Microsoft.EntityFrameworkCore;
using online_school_api.student.Model;
using online_school_api.book.Model;

namespace online_school_api.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Student> Students
        {

            get;set;
        }

        public virtual DbSet<Book> Books
        {

            get;set;
        }





    }
}
