using System;

namespace TimesheetReport.Core.Features.TimeSheets
{
    public class TimeSheet
    {

        public Guid WorkTimeId { get; set; }

        public string ProjectName { get; set; }

        public string Task { get; set; }

        public double Hours { get; set; }

        public double TotalHours { get; set; }

        public DateTime Date { get; set; }
    }
}
