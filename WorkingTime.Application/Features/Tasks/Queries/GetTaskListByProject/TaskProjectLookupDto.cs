using AutoMapper;
using WorkingTime.Application.Common.Mappings;
using WorkingTime.Application.Features.Tasks.Queries.GetTaskList;
using WorkingTime.Domain.Models;

namespace WorkingTime.Application.Features.Tasks.Queries.GetTaskListByProject
{
    public class TaskProjectLookupDto : IMapWith<Project>
    {
        public string ProjectName { get; set; }
        public List<TaskLookupDtoForProject> Tasks { get; set; }

        public void Mapping(Profile profile) 
        {
            profile.CreateMap<Project, TaskProjectLookupDto>()
                .ForMember(tpDto => tpDto.ProjectName,
                    opt => opt.MapFrom(t => t.ProjectName))
                .ForMember(tpDto => tpDto.Tasks,
                    opt => opt.MapFrom(t => t.Tasks));
        }
    }
}
