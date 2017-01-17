using MediatR;
using System.Linq;
using TimesheetReport.Core.Features;
using TimesheetReport.Core.Features.TRUsers;
using TimesheetReport.Core.Infrastructure.DAL;

namespace TimesheetReport.Core.Infrastructure.Handler.TRUsers
{
    public class GetUserFullNameQueryHandler : IRequestHandler<GetUserFullNameQuery, string>
        {
            private readonly ManageUsersDbContext manageUsersDbContext;

            public GetUserFullNameQueryHandler(ManageUsersDbContext manageUsersDbContext)
            {
                this.manageUsersDbContext = manageUsersDbContext;
            }

            public string Handle(GetUserFullNameQuery command)
            {
                var user = manageUsersDbContext
                    .Set<TRUser>()
                    .SingleOrDefault(u => u.Id == command.UserId);
                if (user == null)
                {
                    return "Cannot found this user!";
                }
            var fullName = user.FirstName + " "+ user.LastName;

            return fullName;
            }
        }
}
