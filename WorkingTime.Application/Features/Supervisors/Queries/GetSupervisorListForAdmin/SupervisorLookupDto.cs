using AutoMapper;
using WorkingTime.Application.Common.Mappings;
using WorkingTime.Domain.Models;

namespace WorkingTime.Application.Features.Supervisors.Queries.GetSupervisorListForAdmin
{
    public class SupervisorLookupDto : IMapWith<VwSupervisor>
    {
        public int SupervisorId { get; set; }
        public string Surname { get; set; }
        public string FirstName { get; set; }
        public string? Patronymic { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<VwSupervisor, SupervisorLookupDto>()
                .ForMember(sDto => sDto.SupervisorId,
                    opt => opt.MapFrom(s => s.Id))
                .ForMember(sDto => sDto.Surname,
                    opt => opt.MapFrom(s => s.Surname))
                .ForMember(sDto => sDto.FirstName,
                    opt => opt.MapFrom(s => s.FirstName))
                .ForMember(sDto => sDto.Patronymic,
                    opt => opt.MapFrom(s => s.Patronymic));
        }
    }
}
