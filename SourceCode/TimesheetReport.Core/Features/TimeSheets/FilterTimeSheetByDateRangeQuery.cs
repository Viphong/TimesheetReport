using MediatR;
using System;

namespace TimesheetReport.Core.Features.TimeSheets
{
    public class FilterTimeSheetByDateRangeQuery : IRequest<TimeSheet[]>
    {
        public string UserId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}