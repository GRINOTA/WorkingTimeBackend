using AutoMapper;
using WorkingTime.Application.Common.Mappings;
using WorkingTime.Domain.Models;

namespace WorkingTime.Application.Features.Tasks.Queries.GetTaskDetail.GetTaskDetailForExecutor
{
    public class TaskDetailForExecutorVm : IMapWith<VwProjectsTask>
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string TaskName { get; set; }
        public string? TaskDescription { get; set; }
        public DateTime Deadline { get; set; }
        public string Status { get; set; }
        public DateTime? StartTask { get; set; }
        public DateTime? EndTask { get; set; }
        public string CreatorSurname { get; set; }
        public string CreatorFirstName { get; set; }
        public string? CreatorPatronymic { get; set; }
        public bool IsOverdue { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<VwProjectsTask, TaskDetailForExecutorVm>()
                .ForMember(tdDto => tdDto.Id,
                    opt => opt.MapFrom(task => task.Id))
                .ForMember(tdDto => tdDto.ProjectName,
                    opt => opt.MapFrom(task => task.ProjectName))
                .ForMember(tdDto => tdDto.TaskName,
                    opt => opt.MapFrom(task => task.TaskName))
                .ForMember(tdDto => tdDto.TaskDescription,
                    opt => opt.MapFrom(task => task.TaskDescription))
                .ForMember(tdDto => tdDto.Deadline,
                    opt => opt.MapFrom(task => task.Deadline))
                .ForMember(tdDto => tdDto.Status,
                    opt => opt.MapFrom(task => task.Status))
                .ForMember(tdDto => tdDto.StartTask,
                    opt => opt.MapFrom(task => task.StartTask))
                .ForMember(tdDto => tdDto.EndTask,
                    opt => opt.MapFrom(task => task.EndTask))
                .ForMember(tdDto => tdDto.CreatorSurname,
                    opt => opt.MapFrom(task => task.CreatorSurname))
                .ForMember(tdDto => tdDto.CreatorFirstName,
                    opt => opt.MapFrom(task => task.CreatorFirstName))
                .ForMember(tdDto => tdDto.CreatorPatronymic,
                    opt => opt.MapFrom(task => task.CreatorPatronymic))
                .ForMember(tdDto => tdDto.IsOverdue,
                    opt => opt.MapFrom(task => task.IsOverdue));
        }
    }
}
