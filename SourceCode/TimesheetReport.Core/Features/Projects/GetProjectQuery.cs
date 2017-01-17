using MediatR;
using System;

namespace TimesheetReport.Core.Features.Projects
{
    public class GetProjectQuery : IRequest<Project>
    {
        public Guid ProjectId { get; set; }
    }
}
