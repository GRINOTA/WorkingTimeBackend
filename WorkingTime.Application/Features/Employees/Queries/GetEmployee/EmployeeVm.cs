using AutoMapper;
using WorkingTime.Application.Common.Mappings;
using WorkingTime.Domain.Models;

namespace WorkingTime.Application.Features.Employees.Queries.GetEmployee
{
    public class EmployeeVm : IMapWith<Employee>
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public string Role { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Employee, EmployeeVm>()
                .ForMember(aeVm => aeVm.Id,
                    opt => opt.MapFrom(e => e.Id))
                .ForMember(aeVm => aeVm.Surname,
                    opt => opt.MapFrom(e => e.Surname))
                .ForMember(aeVm => aeVm.FirstName,
                    opt => opt.MapFrom(e => e.FirstName))
                .ForMember(aeVm => aeVm.Patronymic,
                    opt => opt.MapFrom(e => e.Patronymic))
                .ForMember(aeVm => aeVm.Role,
                    opt => opt.MapFrom(e => e.Role));
        }
    }
}
