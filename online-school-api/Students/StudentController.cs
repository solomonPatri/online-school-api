using Microsoft.AspNetCore.Mvc;
using online_school_api.Students.Dtos;
using online_school_api.Students.Exceptions;
using online_school_api.Students.Service;
using System.Security.AccessControl;

namespace online_school_api.Students
{
    [ApiController]
    [Route("api/v1/[Controller]")]
    public class StudentController:ControllerBase
    {

        private readonly IQueryServiceStudent _query;
        private readonly ICommandServiceStudent _command;

        public StudentController(ICommandServiceStudent command,IQueryServiceStudent query)
        {
            _query = query;
            _command = command;

        }

        [HttpGet("allStudents")]

        public async Task<ActionResult<GetAllStudentsDto>> GetAllStudentsAsync()
        {
            try
            {
                GetAllStudentsDto response = await _query.GetAllAsync();

               return  Ok(response);

            }catch(StudentNotFoundException nf)
            {
                return NotFound(nf.Message);
            }

        }

        [HttpPost("create")]

        public async Task<ActionResult<StudentResponse>> CreateAsync([FromBody]StudentRequest studentRequest)
        {
            try
            {
                StudentResponse response = await _command.CreateAsync(studentRequest);
                return Created("", response);



            }catch(StudentAlreadyExistExcept ex)
            {
                return BadRequest(ex.Message);
            }







        }













    }
}
