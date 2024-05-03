﻿using MediatR;

namespace WorkingTime.Application.Projects.Commands.DeleteProject
{
    public class DeleteProjectCommand : IRequest
    {
        public int Id { get; set; }
        public int CreatorId { get; set; }
    }
}
