using System;
using System.ComponentModel.DataAnnotations;
using TimesheetReport.Core.Features.Projects;

namespace TimesheetReport.WebUI.ViewModels.Projects
{
    public class ProjectViewModel
    {
        public ProjectViewModelItem[] Items { get; set; }

        public string SearchText { get; set; }
    }

    public class ProjectViewModelItem
    {
        public Guid ProjectId { get; set; }

        public string ProjectName { get; set; }

        public string ClientName { get; set; }

        public ProjectStatus Status { get; set; }

        public DateTime StartDate { get; set; }

        public Guid IconId { get; set; }

        public string ProjectOwner { get; set; }

        public string Description { get; set; }
    }

    public class AddProjectModel
    {
        public AddProjectModel()
        {
            StartDate = DateTime.Today;
        }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Client Name")]
        public string ClientName { get; set; }

        [Required]
        [Display(Name = "Status")]
        public ProjectStatus Status { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        public Guid? IconId { get; set; }

        [Display(Name = "Project Owner")]
        public string ProjectOwner { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }
    }

    public class EditProjectModel
    {
        public Guid ProjectId { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Client Name")]
        public string ClientName { get; set; }

        [Required]
        [Display(Name = "Status")]
        public ProjectStatus Status { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        public Guid? IconId { get; set; }

        [Display(Name = "Project Owner")]
        public string ProjectOwner { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}