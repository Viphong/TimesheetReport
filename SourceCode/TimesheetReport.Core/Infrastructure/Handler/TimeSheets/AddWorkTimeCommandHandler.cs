using MediatR;
using System;
using TimesheetReport.Core.Features.TimeSheets;
using TimesheetReport.Core.Infrastructure.DAL;

namespace TimesheetReport.Core.Infrastructure.Handler.TimeSheets
{
    public class AddWorkTimeCommandHandler : IRequestHandler<AddWorkTimeCommand, WorkTime>
    {
        private readonly TimesheetReportContext timeSheetDbContext;

        public AddWorkTimeCommandHandler(TimesheetReportContext timeSheetDbContext)
        {
            this.timeSheetDbContext = timeSheetDbContext;
        }

        public WorkTime Handle(AddWorkTimeCommand command)
        {
            WorkTime worktime = new WorkTime()
            {
                ProjectId = command.ProjectId,
                Hours = command.Hours,
                Task = command.Tasks,
                TimeId = Guid.NewGuid(),
                Time = command.AddedDate,
                EmployeeId = command.UserId
            };

            timeSheetDbContext.Set<WorkTime>().Add(worktime);
            timeSheetDbContext.SaveChanges();

            return worktime;
        }
    }
}