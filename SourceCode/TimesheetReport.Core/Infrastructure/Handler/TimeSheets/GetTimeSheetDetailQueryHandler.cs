using MediatR;
using System.Linq;
using TimesheetReport.Core.Features.TimeSheets;
using TimesheetReport.Core.Features.Projects;
using TimesheetReport.Core.Infrastructure.DAL;

namespace TimesheetReport.Core.Infrastructure.Handler.TimeSheets
{
    public class GetTimeSheetDetailQueryHandler : IRequestHandler<GetTimeSheetDetailQuery, TimeSheet[]>
    {
        private readonly TimesheetReportContext timeSheetDbContext;

        public GetTimeSheetDetailQueryHandler(TimesheetReportContext timeSheetDbContext)
        {
            this.timeSheetDbContext = timeSheetDbContext;
        }
        
        public TimeSheet[] Handle(GetTimeSheetDetailQuery command)
        {

            var result = from w in timeSheetDbContext.Set<WorkTime>()
                         join p in timeSheetDbContext.Set<Project>()
                         on w.ProjectId equals p.Id
                         where (w.EmployeeId == command.UserId) && (w.Time == command.SingleDate)
                         select new TimeSheet
                         {
                             ProjectName = p.Name,
                             Hours = w.Hours,
                             Task = w.Task,
                             WorkTimeId = w.TimeId
                         };

            return result.OrderBy(x=>x.ProjectName).ToArray();
        }
    }
}