
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using online_school_api.Enrolments.Model;
using online_school_api.Enrolments.Dto;

namespace online_school_api.Courses.Dto
{
    public class CourseResponse
    {

        public int Id { get; set; }



        public string Name { get; set; }

        public string Departament { get; set; }

  

        public DateTime DateCreated { get; set; }





    }
}
