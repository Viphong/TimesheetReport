using MediatR;
using System;

namespace TimesheetReport.Core.Features.Projects
{
    public class GetProjectsQuery : IRequest<Project[]>
    {
        public Guid ProjectId { get; set; }

        public string Name { get; set; }
    }
}