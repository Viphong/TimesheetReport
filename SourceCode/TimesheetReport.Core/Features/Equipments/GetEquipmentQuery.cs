using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimesheetReport.Core.Features.MyEquipment;

namespace TimesheetReport.Core.Features.Equipments
{
    public class GetEquipmentQuery: IRequest<Equipment[]>
    {

    }
}
