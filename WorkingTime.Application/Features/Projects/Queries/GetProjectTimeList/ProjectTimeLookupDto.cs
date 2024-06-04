using AutoMapper;
using WorkingTime.Application.Common.Mappings;
using WorkingTime.Domain.Models;

namespace WorkingTime.Application.Features.Projects.Queries.GetProjectTimeList
{
    public class ProjectTimeLookupDto: IMapWith<Project>
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public List<Domain.Models.Task> Tasks { get; set; }
        public long? Time { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Project, ProjectTimeLookupDto>()
                .ForMember(projDto => projDto.Id,
                    opt => opt.MapFrom(project => project.Id))
                .ForMember(projDto => projDto.ProjectName,
                    opt => opt.MapFrom(project => project.ProjectName))
                .ForMember(projDto => projDto.Tasks,
                    opt => opt.MapFrom(project => project.Tasks.ToList()))
                .ForMember(projDto => projDto.Time,
                    opt => opt.MapFrom(project => (long)project.Tasks.Sum(t => t.TotalTaskTime)));

        }
    }
}
