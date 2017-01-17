using System;
using TimesheetReport.Core.Features.Utilities;

namespace TimesheetReport.Core.Features.MyEquipment
{
    public class Equipment
    {
        public Equipment()
        {
            Id = SequentialGuidGenerator.NewSequentialGuid();
            AssignOn = DateTime.Now;
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public Guid? ImageId {get; set;}

        public string Desciption { get; set; }

        public EquipmentStatus Status { get; set; }
        /// <summary>
        /// Employee identity user id
        /// </summary>
        public string AssignTo { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Modified { get; set; }

        public DateTime ModifiedOn { get; set; }
        /// <summary>
        /// Should using UTC Time
        /// </summary>
        public DateTime AssignOn { get; set; }

        /// <summary>
        /// Admin identity user id
        /// </summary>
        public string AssignBy { get; set; }

    }
    public enum EquipmentStatus
    {
        Free = 0,
        Using = 1,
        Malfunction = 2
    }
}
