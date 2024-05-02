using AutoMapper;
using WorkingTime.Domain.Models;

namespace WorkingTime.Application.Projects.Queries.GetProjectList
{
    public class ProjectLookupDto
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Project, ProjectLookupDto>()
                .ForMember(projDto => projDto.Id,
                    opt => opt.MapFrom(project => project.Id))
                .ForMember(projDto => projDto.ProjectName,
                    opt => opt.MapFrom(project => project.ProjectName));
        }
    }
}
