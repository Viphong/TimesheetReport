using MediatR;
using System.Linq;
using TimesheetReport.Core.Features.TimeSheets;
using TimesheetReport.Core.Infrastructure.DAL;

namespace TimesheetReport.Core.Infrastructure.Handler.TimeSheets
{
    public class EditWorkTimeCommandHandler : IRequestHandler<EditWorkTimeCommand, string>
    {
        private readonly TimesheetReportContext timeSheetDbContext;

        public EditWorkTimeCommandHandler(TimesheetReportContext timeSheetDbContext)
        {
            this.timeSheetDbContext = timeSheetDbContext;
        }

        public string Handle(EditWorkTimeCommand command)
        {
            var workTime = timeSheetDbContext
                .Set<WorkTime>()
                .SingleOrDefault(x => x.TimeId == command.Id);

            workTime.Hours = command.Hours;
            workTime.ProjectId = command.ProjectId;
            workTime.Task = command.Tasks;

            timeSheetDbContext.SaveChanges();

            return "Edit successfully";
        }
    }
}