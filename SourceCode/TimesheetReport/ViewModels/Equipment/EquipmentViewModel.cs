using System;
using System.ComponentModel.DataAnnotations;
using TimesheetReport.Core.Features.Files;
using TimesheetReport.Core.Features.MyEquipment;

namespace TimesheetReport.WebUI.ViewModels.Equipment
{
    public class MyEquipmentViewModel
    {
        public MyEquipmentViewModelItem [] Items { get; set; }

        public EquipmentViewModel [] EquimentItems { get; set; }
       
    }

    public class MyEquipmentViewModelItem
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public DateTime AssignOn { get; set; }

        public string AssignBy { get; set; }
    }
    public class EquipmentViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public EquipmentStatus Status { get; set; }

        public DateTime CreatedOn { get; set; }

        public string UsingBy { get; set; }
        
    }
    public class AddEquipmentViewModel
    {
        [Required]
        [Display(Name ="Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name ="Code")]
        public string Code { get; set; }

        public Guid? ImageId { get; set; }

        [Display(Name ="Description")]
        public string Description { get; set; }

        [Display(Name ="Status")]
        public EquipmentStatus Status { get; set; }

        [Display(Name ="AssignTo")]
        public string AssignTo { get; set; }

     
    }
}