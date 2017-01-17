using MediatR;
using System;
using System.Linq;
using System.Transactions;
using TimesheetReport.Core.Features.Files;
using TimesheetReport.Core.Features.TRUsers;
using TimesheetReport.Core.Infrastructure.DAL;

namespace TimesheetReport.Core.Infrastructure.Handler.TRUsers
{
    public class UpdateUserProfileCommandHandler : IRequestHandler<UpdateUserProfileCommand, bool>
    {
        private readonly ManageUsersDbContext manageUsersDbContext;
        private readonly TimesheetReportContext timeSheetDbContext;

        public UpdateUserProfileCommandHandler(ManageUsersDbContext manageUsersDbContext, TimesheetReportContext timeSheetDbContext)
        {
            this.manageUsersDbContext = manageUsersDbContext;
            this.timeSheetDbContext = timeSheetDbContext;
        }

        public bool Handle(UpdateUserProfileCommand command)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                try
                {
                    var user = manageUsersDbContext
                            .Set<TRUser>()
                            .SingleOrDefault(x => x.Id == command.UserId);

                    var currentAvt = timeSheetDbContext
                            .Set<File>()
                            .SingleOrDefault(x => x.Id == user.AvartarId);

                    user.FirstName = command.FirstName;
                    user.LastName = command.LastName;
                    user.EnglishName = command.EnglishName;
                    user.Gender = command.Gender;
                    user.DOB = command.DOB;
                    user.IdNumber = command.IdNumber;

                    manageUsersDbContext.SaveChanges();

                    if (command.File != null)
                    {
                        var fileId = AddFile(command.File);
                        if (user.AvartarId != Guid.Empty)
                        {
                            RemoveOldIcon(user.AvartarId);
                        }

                        user.AvartarId = fileId;
                        timeSheetDbContext.SaveChanges();
                        manageUsersDbContext.SaveChanges();
                    }

                    transaction.Complete();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        private void RemoveOldIcon(Guid avatarId)
        {
            var oldAvatar = timeSheetDbContext
                                       .Set<File>()
                                       .SingleOrDefault(f => f.Id == avatarId);

            if (oldAvatar != null)
            {
                timeSheetDbContext
                    .Set<File>()
                    .Remove(oldAvatar);

                timeSheetDbContext.SaveChanges();
            }
        }

        private Guid AddFile(File file)
        {
            file = timeSheetDbContext
                .Set<File>()
                .Add(file);

            timeSheetDbContext.SaveChanges();

            return file.Id;
        }
    }
}