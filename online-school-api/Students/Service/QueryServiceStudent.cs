using online_school_api.Students.Repository;
using System.Diagnostics.SymbolStore;
using online_school_api.Students.Exceptions;
using online_school_api.Students.Model;
using online_school_api.Students.Dtos;
using online_school_api.Enrolments.Dto;
using online_school_api.Enrolments.Exceptions;

namespace online_school_api.Students.Service
{
    public class QueryServiceStudent:IQueryServiceStudent
    {
        private readonly IStudentRepo _repostud;

        public QueryServiceStudent (IStudentRepo repo)
        {

            _repostud = repo;
        }

        public async Task<GetAllStudentsDto> GetAllAsync()
        {
            GetAllStudentsDto response = await _repostud.GetAllAsync();

            if (response != null)
            {
                return response;

            }

            throw new StudentNotFoundException();

        }
   
















    }
}
