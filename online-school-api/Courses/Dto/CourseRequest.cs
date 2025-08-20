using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace online_school_api.Courses.Dto
{
    public class CourseRequest
    {


        [Required]

        public string Name { get; set; }

        [Required]

        public string Departament { get; set; }

      






















    }
}
