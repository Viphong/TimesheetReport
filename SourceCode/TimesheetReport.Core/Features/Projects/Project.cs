using System;
using System.ComponentModel.DataAnnotations;
using TimesheetReport.Core.Features.Utilities;

namespace TimesheetReport.Core.Features.Projects
{
    public class Project
    {
        public Project()
        {
            Id = SequentialGuidGenerator.NewSequentialGuid();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string ClientName { get; set; }

        public ProjectStatus Status { get; set; }

        public DateTime StartDate { get; set; }

        public Guid? IconId { get; set; }

        public string ProjectOwner { get; set; }

        public string Description { get; set; }
    }

    public enum ProjectStatus
    {
        [Display(Name = "In progress")]
        Inprogress = 0,

        [Display(Name = "Maintain")]
        Maintain = 1,

        [Display(Name = "On hold")]
        Onhold = 2
    }
}