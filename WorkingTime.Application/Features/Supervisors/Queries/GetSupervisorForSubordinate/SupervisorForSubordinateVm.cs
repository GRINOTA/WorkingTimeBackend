using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkingTime.Application.Common.Mappings;
using WorkingTime.Application.Features.Employees.Queries.GetEmployee;
using WorkingTime.Domain.Models;

namespace WorkingTime.Application.Features.Supervisors.Queries.GetSupervisorForSubordinate
{
    public class SupervisorForSubordinateVm: IMapWith<VwSupervisorSubordinate>
    {
        public int SupervisorId { get; set; }
        public int SubordinateId { get; set; }
        public string Surname { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<VwSupervisorSubordinate, SupervisorForSubordinateVm>()
                .ForMember(ssVm => ssVm.SupervisorId,
                    opt => opt.MapFrom(e => e.SupervisorId))
                .ForMember(ssVm => ssVm.SubordinateId,
                    opt => opt.MapFrom(e => e.SubordinateId))
                .ForMember(ssVm => ssVm.Surname,
                    opt => opt.MapFrom(e => e.SupervisorSurname))
                .ForMember(ssVm => ssVm.FirstName,
                    opt => opt.MapFrom(e => e.SupervisoFirstName))
                .ForMember(ssVm => ssVm.Patronymic,
                    opt => opt.MapFrom(e => e.SupervisorPatronymic));
        }
    }
}
