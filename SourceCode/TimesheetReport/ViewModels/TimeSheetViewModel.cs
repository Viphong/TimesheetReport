using System;
using TimesheetReport.WebUI.Models;

namespace TimesheetReport.WebUI.ViewModels
{
    public class TimeSheetViewModel
    {
        public TimeSheetItem[] TimeSheetItems { get; set; }

        public ListTimeSheet[] ListTimeSheet { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public ProjectModel[] Projects { get; set; }
    }

    public class AddWorkTimeViewModel
    {
        public Guid ProjectId { get; set; }

        public string Tasks { get; set; }

        public double Hours { get; set; }

        public DateTime AddedDate { get; set; }
}

    public class EditWorkTimeViewModel
    {
        public Guid Id { get; set; }

        public Guid ProjectId { get; set; }

        public string Tasks { get; set; }

        public double Hours { get; set; }
    }

    public class ProjectModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}