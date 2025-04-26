using online_school_api.Enrolments.Dto;

namespace online_school_api.Enrolments.Repository
{
    public interface IEnrolmentRepo
    {

        Task<EnrolmentResponse> CreateEnrolmentAsync(EnrolmentRequest create);








    }
}
