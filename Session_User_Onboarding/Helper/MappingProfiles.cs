using AutoMapper;
using Session_User_Onboarding.Dtos;
using Session_User_Onboarding.Models;

namespace Session_User_Onboarding.Helper
{
    public class MappingProfiles : Profile
    {

        public MappingProfiles()
        {
            //POST MAPPERS
            CreateMap<SessionDto, Session>();
            CreateMap<DepartmentDto, Department>();

            //PUT MAPPERS
            CreateMap<SessionGetDto, Session>();

            //GET MAPPERS
            CreateMap<Session, SessionDto>();
            CreateMap<Session, SessionGetDto>(); 
            CreateMap<Department, DepartmentDto>();

        }
    }
}
