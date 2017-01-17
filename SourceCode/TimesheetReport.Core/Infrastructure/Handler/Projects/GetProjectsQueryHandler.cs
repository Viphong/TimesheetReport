using MediatR;
using System.Linq;
using TimesheetReport.Core.Features.Projects;
using TimesheetReport.Core.Infrastructure.DAL;
using TimesheetReport.Core.Infrastructure.Handler.Projects;

namespace TimesheetReport.Core.Infrastructure.Handler.Projects
{
    public class GetProjectsQueryHandler : IRequestHandler<GetProjectsQuery, Project[]>
    {
        private readonly TimesheetReportContext timeSheetDbContext;
        private readonly ManageUsersDbContext manageUsersDbContext;

        public GetProjectsQueryHandler(
            TimesheetReportContext timeSheetDbContext,
            ManageUsersDbContext manageUsersDbContext)
        {
            this.timeSheetDbContext = timeSheetDbContext;
            this.manageUsersDbContext = manageUsersDbContext;
        }

        public Project[] Handle(GetProjectsQuery query)
        {
            var projects = timeSheetDbContext
                            .Set<Project>()
                            .ToArray();

            if (projects == null)
            {
                return new Project[0];
            }

            return projects;
        }
    }
}