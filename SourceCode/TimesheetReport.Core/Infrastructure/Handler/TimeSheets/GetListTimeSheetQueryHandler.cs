using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using TimesheetReport.Core.Features.TimeSheets;
using TimesheetReport.Core.Infrastructure.DAL;

namespace TimesheetReport.Core.Infrastructure.Handler.TimeSheets
{

    public class GetListTimeSheetQueryHandler : IRequestHandler<GetListTimeSheetQuery, TimeSheet[]>
    {
        private readonly TimesheetReportContext timeSheetDbContext;

        public GetListTimeSheetQueryHandler(TimesheetReportContext timeSheetDbContext)
        {
            this.timeSheetDbContext = timeSheetDbContext;
        }

        public TimeSheet[] Handle(GetListTimeSheetQuery command)
        {
            var timeSheetList = new List<TimeSheet>();

            for (DateTime i = command.StartDate; i <= command.EndDate; i = i.AddDays(1))
            {
                timeSheetList.Add(new TimeSheet
                {
                    Date = i.Date,
                    TotalHours = 0
                });
            }

            var workTime = timeSheetDbContext
                .Set<WorkTime>()
                .Where(x => x.Time >= command.StartDate
                    && x.Time <= command.EndDate
                    && x.EmployeeId == command.UserId)
                .GroupBy(x => x.Time)
                .Select(w => new TimeSheet
                {
                    TotalHours = w.Sum(x => x.Hours),
                    Date = w.FirstOrDefault().Time
                }).ToList();

            foreach (var item in timeSheetList)
            {
                var data = workTime
                    .Where(n => n.Date == item.Date)
                    .SingleOrDefault();

                if (data != null)
                {
                    item.TotalHours = data.TotalHours;
                }
            }

            return timeSheetList.ToArray();
        }
    }
}
