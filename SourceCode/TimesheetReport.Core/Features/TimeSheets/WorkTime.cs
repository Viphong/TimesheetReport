using System;

namespace TimesheetReport.Core.Features.TimeSheets
{
    public class WorkTime
    {
        public Guid TimeId { get; set; }

        public Guid ProjectId { get; set; }

        public string EmployeeId { get; set; }

        public string Task { get; set; }

        public double Hours { get; set; }

        public DateTime Time { get; set; }
    }
}
