using MediatR;
using System.Data.SqlClient;
using System.Linq;
using TimesheetReport.Core.Features.Projects;
using TimesheetReport.Core.Infrastructure.DAL;

namespace TimesheetReport.Core.Infrastructure.Handler.Projects
{
    public class GetListProjectsQueryHandler : IRequestHandler<GetListProjectsQuery, Project[]>
    {
        private readonly TimesheetReportContext timeSheetDbContext;

        public GetListProjectsQueryHandler(
            TimesheetReportContext timeSheetDbContext)
        {
            this.timeSheetDbContext = timeSheetDbContext;
        }

        public Project[] Handle(GetListProjectsQuery query)
        {
            var searchText = string.IsNullOrEmpty(query.SearchText) ? "%%" : $"%{query.SearchText}%";
            var rawQuery = @"
SELECT Id
      ,Name
      ,ClientName
      ,Status
      ,StartDate
      ,IconId
      ,ProjectOwner
      ,Description
FROM TR.Projects P
WHERE P.Name LIKE @SearchText
      OR P.ProjectOwner LIKE @SearchText
      OR P.ClientName LIKE @SearchText;";

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@SearchText", searchText)
            };

            return timeSheetDbContext
                    .Set<Project>()
                    .SqlQuery(rawQuery, parameters)
                    .ToArray();
        }
    }
}
