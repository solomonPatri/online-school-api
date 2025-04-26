using AutoMapper;
using online_school_api.Data;
using online_school_api.Enrolments.Dto;
using online_school_api.Enrolments.Model;
using System.Diagnostics;

namespace online_school_api.Enrolments.Repository
{
    public class EnrolmentRepo:IEnrolmentRepo
    {

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public EnrolmentRepo(AppDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;

        }

        public async Task<EnrolmentResponse> CreateEnrolmentAsync(EnrolmentRequest create)
        {
            var enr = _mapper.Map<Enrolment>(create);

            await _context.Enrolments.AddAsync(enr);

            _context.SaveChangesAsync();

            var response = _mapper.Map<EnrolmentResponse>(enr);

            return response;

        }

       





    }
}
