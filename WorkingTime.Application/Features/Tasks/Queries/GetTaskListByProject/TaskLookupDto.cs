﻿using AutoMapper;
using WorkingTime.Application.Common.Mappings;

namespace WorkingTime.Application.Features.Tasks.Queries.GetTaskListByProject
{
    public class TaskLookupDtoForProject : IMapWith<Domain.Models.Task>
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string TaskName { get; set; }
        public string Status { get; set; }
        public bool IsOverdue { get; set; }
        public DateTime Deadline { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Models.Task, TaskLookupDtoForProject>()
                .ForMember(taskDto => taskDto.Id,
                    opt => opt.MapFrom(task => task.Id))
                .ForMember(taskDto => taskDto.ProjectId,
                    opt => opt.MapFrom(task => task.ProjectId))
                .ForMember(taskDto => taskDto.TaskName,
                    opt => opt.MapFrom(task => task.TaskName))
                .ForMember(taskDto => taskDto.Status,
                    opt => opt.MapFrom(task => task.Status))
                .ForMember(taskDto => taskDto.Deadline,
                    opt => opt.MapFrom(task => task.Deadline))
                .ForMember(taskDto => taskDto.IsOverdue,
                    opt => opt.MapFrom(task => task.IsOverdue));
        }
    }
}
