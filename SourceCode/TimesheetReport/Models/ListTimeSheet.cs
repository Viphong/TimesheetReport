using System;

namespace TimesheetReport.WebUI.Models
{
    public class ListTimeSheet
    {
        public double TotalHours { get; set; }

        public DateTime Date { get; set; }

        public Guid Id { get; set; }
    }
}