using System.ComponentModel.DataAnnotations;

namespace online_school_api.Enrolments.Dto
{
    public class EnrolmentRequest
    {

        [Required]
         
        public int StudentId { get; set; }

        [Required]

        public int CourseId { get; set; }




















    }
}
