using online_school_api.Courses.Model;
using online_school_api.Students.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace online_school_api.Enrolments.Model
{
    [Table("enrolments")]
    public class Enrolment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]

        public int Id { get; set; }

        public int StudentId { get; set; }

        public int CourseId { get; set; }

        [Required]
        [Column("created")]

        public string Created { get; set; }


        public virtual Student Student { get; set; }

        public virtual Course Course { get; set; }





    }
}
