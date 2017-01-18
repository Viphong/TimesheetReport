using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimesheetReport.Core.Features.Equipments;
using TimesheetReport.Core.Features.MyEquipment;
using TimesheetReport.Core.Infrastructure.DAL;

namespace TimesheetReport.Core.Infrastructure.Handler
{
    public class GetEquipmentQueryHandler : IRequestHandler<GetEquipmentQuery, Equipment[]>
    {
        private readonly TimesheetReportContext timesheetreportContext;
        public GetEquipmentQueryHandler(TimesheetReportContext _timesheetReportContext)
        {
            this.timesheetreportContext = _timesheetReportContext;
        }
        public Equipment[] Handle(GetEquipmentQuery command)
        {
            return timesheetreportContext.Set<Equipment>().OrderByDescending(x => x.CreatedOn).ToArray();
        }
    }
}
