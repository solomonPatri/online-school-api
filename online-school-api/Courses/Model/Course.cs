
using Microsoft.AspNetCore.Mvc;
using online_school_api;
using online_school_api.Enrolments.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace online_school_api.Courses.Model
{
    [Table("courses")]
    public class Course
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]

        public int Id { get; set; }


        [Required]
        [Column("name")]

        public string Name  { get; set; }

        [Required]
        [Column("departament")]

        public string Departament { get; set; }

        [Required]
        [Column("dateCreated")]

        public DateTime DateCreated { get; set; }


        public virtual List<Enrolment> Enrolments { get; set; }





    }
}
