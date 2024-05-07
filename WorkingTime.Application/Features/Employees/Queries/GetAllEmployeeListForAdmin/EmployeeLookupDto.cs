using AutoMapper;
using WorkingTime.Application.Common.Mappings;
using WorkingTime.Domain.Models;

namespace WorkingTime.Application.Features.Employees.Queries.GetAllEmployeeListForAdmin
{
    public class EmployeeLookupDto : IMapWith<Employee>
    {
        public int Id { get; set; }
        public string Role { get; set; }
        public string Surname { get; set; }
        public string FirstName { get; set; }
        public string? Patronymic { get; set; }

        public string Login { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Employee, EmployeeLookupDto>()
                .ForMember(emDto => emDto.Id,
                    opt => opt.MapFrom(task => task.Id))
                .ForMember(emDto => emDto.Role,
                    opt => opt.MapFrom(task => task.Role))
                .ForMember(emDto => emDto.Surname,
                    opt => opt.MapFrom(task => task.Surname))
                .ForMember(emDto => emDto.FirstName,
                    opt => opt.MapFrom(task => task.FirstName))
                .ForMember(emDto => emDto.Patronymic,
                    opt => opt.MapFrom(task => task.Patronymic))
                .ForMember(emDto => emDto.Login,
                    opt => opt.MapFrom(task => task.Login));
        }
    }
}
