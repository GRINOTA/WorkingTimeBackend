using AutoMapper;
using WorkingTime.Application.Common.Mappings;
using WorkingTime.Domain.Models;

namespace WorkingTime.Application.Features.Tasks.Queries.GetTaskDetail.GetTaskDetailForCreator
{
    public class TaskDetailForCreatorVm : IMapWith<VwProjectsTask>
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string TaskName { get; set; }
        public string? TaskDescription { get; set; }
        public DateTime Deadline { get; set; }
        public string Status { get; set; }
        public DateTime? StartTask { get; set; }
        public DateTime? EndTask { get; set; }
        public string ExecutorSurname { get; set; }
        public string ExecutorFirstName { get; set; }
        public string? ExecutorPatronymic { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<VwProjectsTask, TaskDetailForCreatorVm>()
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
                .ForMember(tdDto => tdDto.ExecutorSurname,
                    opt => opt.MapFrom(task => task.ExecutorSurname))
                .ForMember(tdDto => tdDto.ExecutorFirstName,
                    opt => opt.MapFrom(task => task.ExecutorFirstName))
                .ForMember(tdDto => tdDto.ExecutorPatronymic,
                    opt => opt.MapFrom(task => task.ExecutorPatronymic));
        }


    }
}
