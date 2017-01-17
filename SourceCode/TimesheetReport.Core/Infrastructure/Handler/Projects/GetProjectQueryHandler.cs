using MediatR;
using System.Linq;
using TimesheetReport.Core.Features.Projects;
using TimesheetReport.Core.Infrastructure.DAL;

namespace TimesheetReport.Core.Infrastructure.Handler.Projects
{
    public class GetProjectQueryHandler : IRequestHandler<GetProjectQuery, Project>
    {
        private readonly TimesheetReportContext timeSheetDbContext;

        public GetProjectQueryHandler(
            TimesheetReportContext timeSheetDbContext)
        {
            this.timeSheetDbContext = timeSheetDbContext;
        }

        public Project Handle(GetProjectQuery query)
        {

            return timeSheetDbContext
                            .Set<Project>()
                            .SingleOrDefault(p => p.Id == query.ProjectId);
        }
    }
}
