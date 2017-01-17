using MediatR;
using System;

namespace TimesheetReport.Core.Features.MyEquipment
{
    public class GetEquipmentsOfEmployeeQuery : IRequest<Equipment[]>
    {
        public string UserId { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        /// <summary>
        /// Should using UTC Time
        /// </summary>
        public DateTime AssignOn { get; set; }

        /// <summary>
        /// Admin identity user id
        /// </summary>
        public string AssignBy { get; set; }

        /// <summary>
        /// Employee identity user id
        /// </summary>
        public string AssignTo { get; set; }
    }
}
