using Microsoft.AspNetCore.Mvc;
using online_school_api.Courses.Dto;
using online_school_api.Courses.Exceptions;
using online_school_api.Courses.Services;
using online_school_api.Enrolments.Dto;
using System.Security.AccessControl;

namespace online_school_api.Courses
{
    [ApiController]
    [Route("api/V3/[Controller]")]
    public class CourseController:ControllerBase
    {
        private readonly ICourseCommandService _command;
        private readonly ICourseQueryService _query;


        public CourseController(ICourseQueryService query, ICourseCommandService command)
        {
            this._command = command;
            this._query = query;

        }

        [HttpGet("allCourse")]

        public async Task<ActionResult<GetAllCourseDtos>> GetAllCourseAsync()
        {
            try
            {

                GetAllCourseDtos response = await _query.GetAllCourseAsync();

                return Ok(response);



            }catch(CourseNotFoundException nf)
            {
                return NotFound(nf.Message);
            }





        }


        [HttpPost("create")]


        public async Task<ActionResult<CourseResponse>> CreateAsync([FromBody] CourseRequest create)
        { 

            try
            {
                CourseResponse response = await _command.CreateCourseAsync(create);

                return Created("",response);

            }catch(CourseAlreadyExistException ex)
            {

                return BadRequest(ex.Message);
            }


        }

        [HttpPut("updateCourse/{id}")]
        
        public async Task<ActionResult<CourseResponse>> UdpateCourseAsync([FromRoute]int id, [FromBody]CourseUpdateRequest update)
        {


            try
            {
                CourseResponse response = await _command.UpdateCourseAsync(id, update);

                return Accepted("", response);



            }catch(CourseNotFoundException nf)
            {
                return NotFound(nf.Message);
            }

        }

        [HttpDelete("deleteCourse/{id}")]


        public async Task<ActionResult<CourseResponse>> DeleteCourseAsync([FromRoute]int id)
        {

            try
            {
                CourseResponse response = await _command.DeleteCourseAsync(id);

                return Accepted("", response);

            }catch(CourseNotFoundException nf)
            {
                return NotFound(nf.Message);
            }


        }

        [HttpGet("most-popular-course")]

        public async Task<ActionResult<CourseResponse>> GetCourseMostPopular()
        {
            try
            {

                CourseResponse response = await _query.GetCourseMostPopular();

                return Ok(response);

            }catch(CourseNotFoundException nf) {

                return NotFound(nf.Message);
            
            }




        }







    }
}
