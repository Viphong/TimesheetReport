using MediatR;
using System;
using TimesheetReport.Core.Features.TRUsers;
using TimesheetReport.Core.Infrastructure.DAL;

namespace TimesheetReport.Core.Infrastructure.Handler.TRUsers
{
    public class RegisterUserCommandHandler: IRequestHandler<RegisterUserCommand, TRUser>
    {
        private readonly ManageUsersDbContext manageUsersDbContext;

        public RegisterUserCommandHandler(ManageUsersDbContext manageUsersDbContext)
        {
            this.manageUsersDbContext = manageUsersDbContext;
        }

        public TRUser Handle(RegisterUserCommand command)
        {
            var user = new TRUser
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                EnglishName = command.EnglishName,
                Gender = command.Genders,
                DOB = command.DOB,
                IdNumber = command.IdNumber,
                Email = command.Email,
                UserName = command.Email,
                SecurityStamp = Guid.NewGuid().ToString("D"),
                EmailConfirmed = true,
                Status = (int)UserStatus.Active
            };

            user = manageUsersDbContext
                .Set<TRUser>()
                .Add(user);

            manageUsersDbContext.SaveChanges();

            return user;
        }
    }
}
