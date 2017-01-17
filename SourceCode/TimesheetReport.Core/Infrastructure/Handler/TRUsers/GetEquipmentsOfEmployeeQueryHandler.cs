using MediatR;
using System.Linq;
using TimesheetReport.Core.Features.MyEquipment;
using TimesheetReport.Core.Infrastructure.DAL;

namespace TimesheetReport.Core.Infrastructure.Handler.MyEquipment
{
    public class GetEquipmentsOfEmployeeQueryHandler : IRequestHandler<GetEquipmentsOfEmployeeQuery, Equipment[]>
    {
        private readonly TimesheetReportContext timeSheetDbContext;
        private readonly ManageUsersDbContext manageUsersDbContext;

        public GetEquipmentsOfEmployeeQueryHandler(TimesheetReportContext timeSheetDbContext, ManageUsersDbContext manageUsersDbContext)
        {
            this.timeSheetDbContext = timeSheetDbContext;
            this.manageUsersDbContext = manageUsersDbContext;
        }

        public Equipment[] Handle(GetEquipmentsOfEmployeeQuery query)
        {
            var equipments = timeSheetDbContext
                        .Set<Equipment>()
                        .Where(x => x.AssignTo == query.UserId)
                        .OrderByDescending(x => x.AssignOn)
                        .ToArray();

            if (equipments == null)
            {
                return new Equipment[0];
            }

            return equipments;
        }
    }
}
