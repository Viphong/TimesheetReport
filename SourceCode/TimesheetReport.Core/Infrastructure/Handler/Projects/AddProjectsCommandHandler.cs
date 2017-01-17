using MediatR;
using System;
using System.Transactions;
using TimesheetReport.Core.Features.Files;
using TimesheetReport.Core.Features.Projects;
using TimesheetReport.Core.Infrastructure.DAL;

namespace TimesheetReport.Core.Infrastructure.Handler.Projects
{
    public class AddProjectsCommandHandler : IRequestHandler<AddProjectsCommand, bool>
    {
        private readonly TimesheetReportContext timeSheetDbContext;

        public AddProjectsCommandHandler(
            TimesheetReportContext timeSheetDbContext)
        {
            this.timeSheetDbContext = timeSheetDbContext;
        }

        public bool Handle(AddProjectsCommand command)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                try
                {
                    var project = AddProject(command);
                    if (command.File != null)
                    {
                        var fileId = AddIcon(command.File);
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

        private Guid AddIcon(File file)
        {
            file = timeSheetDbContext
                .Set<File>()
                .Add(file);

            timeSheetDbContext.SaveChanges();

            return file.Id;
        }

        private Project AddProject(AddProjectsCommand command)
        {
            var project = new Project
            {
                Name = command.Name,
                ClientName = command.ClientName,
                StartDate = command.StartDate,
                Status = command.Status,
                ProjectOwner = command.ProjectOwner,
                Description = command.Description
            };

            project = timeSheetDbContext
                    .Set<Project>()
                    .Add(project);

            timeSheetDbContext.SaveChanges();

            return project;
        }
    }
}
