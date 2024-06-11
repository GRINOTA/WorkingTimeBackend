using AutoMapper;
using MediatR.Pipeline;
using WorkingTime.Application.Common.Mappings;
using WorkingTime.Domain.Models;

namespace WorkingTime.Application.Features.Tasks.Queries.GetTaskList
{
    public class TaskLookupDto : IMapWith<VwProjectsTask>
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public int ExecutorId { get; set; }
        public string SurnameExecutor { get; set; }
        public string FirstNameExecutor { get; set; }
        public string? PatronymicExecutor { get; set; }
        public string TaskName { get; set; }
        public string Status { get; set; }
        public bool IsOverdue { get; set; }
        public DateTime Deadline { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Models.VwProjectsTask, TaskLookupDto>()
                .ForMember(taskDto => taskDto.Id,
                    opt => opt.MapFrom(task => task.Id))
                .ForMember(taskDto => taskDto.ProjectId,
                    opt => opt.MapFrom(task => task.ProjectId))
                .ForMember(taskDto => taskDto.ProjectName,
                    opt => opt.MapFrom(task => task.ProjectName))
                .ForMember(taskDto => taskDto.SurnameExecutor,
                    opt => opt.MapFrom(task => task.ExecutorSurname))
                .ForMember(taskDto => taskDto.FirstNameExecutor,
                    opt => opt.MapFrom(task => task.ExecutorFirstName))
                .ForMember(taskDto => taskDto.PatronymicExecutor,
                    opt => opt.MapFrom(task => task.ExecutorPatronymic))
                .ForMember(taskDto => taskDto.Status,
                    opt => opt.MapFrom(task => task.Status))
                .ForMember(taskDto => taskDto.Deadline,
                    opt => opt.MapFrom(task => task.Deadline))
                .ForMember(taskDto => taskDto.IsOverdue,
                    opt => opt.MapFrom(task => task.IsOverdue));
        }
    }
}
