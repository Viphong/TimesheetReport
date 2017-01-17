using MediatR;
using System.Linq;
using TimesheetReport.Core.Features.Files;
using TimesheetReport.Core.Infrastructure.DAL;

namespace TimesheetReport.Core.Infrastructure.Handler.Files
{
    public class GetFileByFileIdQueryHandler : IRequestHandler<GetFileByFileIdQuery, File>
    {
        private readonly TimesheetReportContext timeSheetDbContext;

        public GetFileByFileIdQueryHandler(TimesheetReportContext timeSheetDbContext)
        {
            this.timeSheetDbContext = timeSheetDbContext;
        }

        public File Handle(GetFileByFileIdQuery query)
        {
            return timeSheetDbContext
                .Set<File>()
                .Where(f => f.Id == query.FileId)
                .SingleOrDefault();
        }
    }
}
