using MediatR;
using System;
using System.Linq;
using System.Transactions;
using TimesheetReport.Core.Features.Files;
using TimesheetReport.Core.Features.Projects;
using TimesheetReport.Core.Infrastructure.DAL;

namespace TimesheetReport.Core.Infrastructure.Handler.Projects
{
    public class EditProjectsCommandHandler : IRequestHandler<EditProjectsCommand, bool>
    {
        private readonly TimesheetReportContext timeSheetDbContext;

        public EditProjectsCommandHandler(TimesheetReportContext timeSheetDbContext)
        {
            this.timeSheetDbContext = timeSheetDbContext;
        }

        public bool Handle(EditProjectsCommand command)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                try
                {
                    var project = timeSheetDbContext
                                    .Set<Project>()
                                    .SingleOrDefault(x => x.Id == command.ProjectId);

                    UpdateProject(project, command);

                    if (command.File != null)
                    {
                        var fileId = AddFile(command.File);

                        if (project.IconId.HasValue)
                        {
                            RemoveOldIcon(project.IconId.Value);
                        }

                        project.IconId = fileId;
                        timeSheetDbContext.SaveChanges();
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

        private void RemoveOldIcon(Guid iconId)
        {
            var oldIcon = timeSheetDbContext
                                        .Set<File>()
                                        .SingleOrDefault(f => f.Id == iconId);

            if (oldIcon != null)
            {
                timeSheetDbContext
                    .Set<File>()
                    .Remove(oldIcon);

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

        private void UpdateProject(Project project, EditProjectsCommand command)
        {
            project.Name = command.Name;
            project.ClientName = command.ClientName;
            project.Status = command.Status;
            project.StartDate = command.StartDate;
            project.ProjectOwner = command.ProjectOwner;
            project.Description = command.Description;

            timeSheetDbContext.SaveChanges();
        }
    }
}
