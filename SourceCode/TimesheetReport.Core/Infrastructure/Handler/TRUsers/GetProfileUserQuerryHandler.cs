using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimesheetReport.Core.Features.Files;
using TimesheetReport.Core.Infrastructure.DAL;

namespace TimesheetReport.Core.Features.TRUsers
{
    public class GetProfileUserQuerryHandler : IRequestHandler<GetProfileUserQuerry, TRUser>
    {
        private readonly ManageUsersDbContext manageUsersDbContext;

        public GetProfileUserQuerryHandler(ManageUsersDbContext manageUsersDbContext)
        {
            this.manageUsersDbContext = manageUsersDbContext;
        }

        public TRUser Handle(GetProfileUserQuerry query)
        {
            return manageUsersDbContext
                    .Set<TRUser>()
                            .SingleOrDefault(x => x.Id == query.UserId);
        }
    }
}
