using MediatR;
using System.Linq;
using TimesheetReport.Core.Features.TimeSheets;
using TimesheetReport.Core.Infrastructure.DAL;

namespace TimesheetReport.Core.Infrastructure.Handler.TimeSheets
{
    public class FilterTimeSheetByDateRangeQueryHandler : IRequestHandler<FilterTimeSheetByDateRangeQuery, TimeSheet[]>
    {
        private readonly TimesheetReportContext timeSheetDbContext;

        public FilterTimeSheetByDateRangeQueryHandler(TimesheetReportContext timeSheetDbContext)
        {
            this.timeSheetDbContext = timeSheetDbContext;
        }

        public TimeSheet[] Handle(FilterTimeSheetByDateRangeQuery command)
        {
            var result = timeSheetDbContext.Set<WorkTime>()
                .Where(x => x.Time >= command.StartDate)
                .Where(y => y.Time <= command.EndDate)
                .Where(x => x.EmployeeId == command.UserId)
                .GroupBy(x => x.Time)
                .Select(w => new TimeSheet
                 {
                     TotalHours = w.Sum(x => x.Hours),
                     Date = w.FirstOrDefault().Time
                 }).ToArray();
            return result;
        }
    }
}