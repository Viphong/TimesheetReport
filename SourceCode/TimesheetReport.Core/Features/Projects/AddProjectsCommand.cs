using MediatR;
using System;
using TimesheetReport.Core.Features.Files;

namespace TimesheetReport.Core.Features.Projects
{
    public class AddProjectsCommand : IRequest<bool>
    {
        public Guid ProjectId { get; set; }

        public string Name { get; set; }

        public string ClientName { get; set; }

        public ProjectStatus Status { get; set; }

        public DateTime StartDate { get; set; }

        public string ProjectOwner { get; set; }

        public string Description { get; set; }

        public File File { get; set; }
    }
}
