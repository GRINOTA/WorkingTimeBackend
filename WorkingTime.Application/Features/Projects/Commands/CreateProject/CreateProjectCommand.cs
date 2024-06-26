﻿using MediatR;

namespace WorkingTime.Application.Features.Projects.Commands.CreateProject
{
    public class CreateProjectCommand : IRequest<int>
    {
        public int CreatorId { get; set; }
        public string ProjectName { get; set; }

        public string? ProjectDescription { get; set; }
    }
}
