using System;

namespace TimesheetReport.WebUI.Models
{
    public class TimeSheetItem
    {
        public Guid WorkTimeId { get; set; }

        public string ProjectName { get; set; }

        public string Tasks { get; set; }

        public double Hours { get; set; }

        public double TotalHours { get; set; }
    }
}