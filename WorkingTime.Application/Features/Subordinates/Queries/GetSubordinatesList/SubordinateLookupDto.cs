using AutoMapper;
using WorkingTime.Application.Common.Mappings;
using WorkingTime.Domain.Models;

namespace WorkingTime.Application.Features.Subordinates.Queries.GetSubordinatesList
{
    public class SubordinateLookupDto : IMapWith<VwSupervisorSubordinate>
    {
        public int SubordinateId { get; set; }
        public int SupervisorId { get; set; }
        public string Surname { get; set; }
        public string FirstName { get; set; }
        public string? Patronymic { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<VwSupervisorSubordinate, SubordinateLookupDto>()
                .ForMember(sDto => sDto.SupervisorId,
                    opt => opt.MapFrom(s => s.SubordinateId))
                .ForMember(sDto => sDto.SupervisorId,
                    opt => opt.MapFrom(s => s.SupervisorId))
                .ForMember(sDto => sDto.Surname,
                    opt => opt.MapFrom(s => s.SubordinateSurname))
                .ForMember(sDto => sDto.FirstName,
                    opt => opt.MapFrom(s => s.SubordinateFirstName))
                .ForMember(sDto => sDto.Patronymic,
                    opt => opt.MapFrom(s => s.SubordinatePatronymic));
        }
    }
}
