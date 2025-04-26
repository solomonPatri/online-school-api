using AutoMapper;
using online_school_api.Enrolments.Dto;
using online_school_api.Enrolments.Model;

namespace online_school_api.Enrolments.Mappers
{
    public class EnrolmentMappingProfile:Profile
    {
        public  EnrolmentMappingProfile()
        {
            CreateMap<EnrolmentRequest, Enrolment>();
            CreateMap<Enrolment, EnrolmentResponse>();
            


        }
















    }
}
