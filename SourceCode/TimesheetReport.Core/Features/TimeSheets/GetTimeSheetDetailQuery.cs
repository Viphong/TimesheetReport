using MediatR;
using System;

namespace TimesheetReport.Core.Features.TimeSheets
{
    public class GetTimeSheetDetailQuery : IRequest<TimeSheet[]>
    {
        public string UserId { get; set; }

        public DateTime SingleDate { get; set; }
    }
}