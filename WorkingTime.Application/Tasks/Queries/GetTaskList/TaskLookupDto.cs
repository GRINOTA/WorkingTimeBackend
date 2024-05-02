using AutoMapper;

namespace WorkingTime.Application.Tasks.Queries.GetTaskList
{
    public class TaskLookupDto
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public string Status { get; set; }
        public DateTime Deadline { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Models.Task, TaskLookupDto>()
                .ForMember(taskDto => taskDto.Id,
                    opt => opt.MapFrom(task => task.Id))
                .ForMember(taskDto => taskDto.TaskName,
                    opt => opt.MapFrom(task => task.TaskName))
                .ForMember(taskDto => taskDto.Status,
                    opt => opt.MapFrom(task => task.Status))
                .ForMember(taskDto => taskDto.Deadline,
                    opt => opt.MapFrom(task => task.Deadline));
        }
    }
}
