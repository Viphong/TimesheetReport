using MediatR;
using System.Linq;
using TimesheetReport.Core.Features.TimeSheets;
using TimesheetReport.Core.Infrastructure.DAL;

namespace TimesheetReport.Core.Infrastructure.Handler.TimeSheets
{
    public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, string>
    {
        private readonly TimesheetReportContext timeSheetDbContext;

        public DeleteTaskCommandHandler(TimesheetReportContext timeSheetDbContext)
        {
            this.timeSheetDbContext = timeSheetDbContext;
        }

        public string Handle(DeleteTaskCommand command)
        {
            var task = timeSheetDbContext.Set<WorkTime>().Where(x => x.TimeId == command.TaskId);

            timeSheetDbContext.Set<WorkTime>().RemoveRange(task);
            timeSheetDbContext.SaveChanges();

            return "Add successfully";
        }
    }
}