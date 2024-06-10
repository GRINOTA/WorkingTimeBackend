using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingTime.Application.Features.Supervisors.Queries.GetSupervisorForSubordinate
{
    public class GetSupervisorForSubordinateQuery: IRequest<SupervisorForSubordinateVm>
    {
        public int SubordinateId { get; set; }
    }
}
