using AutoMapper;
using WorkingTime.Application.Common.Mappings;
using WorkingTime.Domain.Models;

namespace WorkingTime.Application.Features.Employees.Queries.GetEmployeeDetailForAdmin
{
    public class EmployeeDetailVm : IMapWith<Employee>
    {
        public int Id { get; set; }
        public string Role { get; set; }
        public string Surname { get; set; }
        public string FirstName { get; set; }
        public string? Patronymic { get; set; }
        public string Login { get; set; }
        public IList<Subordinate>? Subordinates { get; set; }
        public Supervisor? Supervisor { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Employee, EmployeeDetailVm>()
                .ForMember(edVm => edVm.Id,
                    opt => opt.MapFrom(e => e.Id))
                .ForMember(edVm => edVm.Role,
                    opt => opt.MapFrom(e => e.Role))
                .ForMember(edVm => edVm.Surname,
                    opt => opt.MapFrom(e => e.Surname))
                .ForMember(edVm => edVm.FirstName,
                    opt => opt.MapFrom(e => e.FirstName))
                .ForMember(edVm => edVm.Patronymic,
                    opt => opt.MapFrom(e => e.Patronymic))
                .ForMember(edVm => edVm.Login,
                    opt => opt.MapFrom(e => e.Login));
        }
    }
}
