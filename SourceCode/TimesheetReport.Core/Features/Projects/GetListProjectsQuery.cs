using MediatR;
using System;

namespace TimesheetReport.Core.Features.Projects
{
    public class GetListProjectsQuery : IRequest<Project[]>
    {
        public string SearchText { get; set; }
    }
}
