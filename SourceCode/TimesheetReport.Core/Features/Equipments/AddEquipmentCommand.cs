using MediatR;
using TimesheetReport.Core.Features.Files;
using TimesheetReport.Core.Features.MyEquipment;

namespace TimesheetReport.Core.Features.Equipments
{
    public class AddEquipmentCommand: IRequest
    {
       
        public string UserName { get; set; }

        public string Name { get; set; }

        public  string Code { get; set; }

        public string Description { get; set; }

        public EquipmentStatus Status { get; set; }

        public string CreatedOn { get; set; }

        public string AssignTo { get; set; }

        public File File { get; set; }
    }
}
