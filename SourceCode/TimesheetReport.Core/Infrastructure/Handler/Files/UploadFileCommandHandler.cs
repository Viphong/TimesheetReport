using MediatR;
using System;
using TimesheetReport.Core.Features.Files;
using TimesheetReport.Core.Infrastructure.DAL;

namespace TimesheetReport.Core.Infrastructure.Handler.Files
{
    public class UploadFileCommandHandler : IRequestHandler<UploadFileCommand, string>
    {
        private readonly TimesheetReportContext timeSheetDbContext;

        public UploadFileCommandHandler(
            TimesheetReportContext timeSheetDbContext)
        {
            this.timeSheetDbContext = timeSheetDbContext;
        }

        public string Handle(UploadFileCommand command)
        {
            try
            {
                timeSheetDbContext.Set<File>().Add(command.File);
                timeSheetDbContext.SaveChanges();

                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
