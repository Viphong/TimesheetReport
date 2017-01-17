using MediatR;
using System;
using System.Transactions;
using TimesheetReport.Core.Features.Equipments;
using TimesheetReport.Core.Features.Files;
using TimesheetReport.Core.Features.MyEquipment;
using TimesheetReport.Core.Infrastructure.DAL;

namespace TimesheetReport.Core.Infrastructure.Handler
{
    public class AddEquipmentCommandHandler : RequestHandler<AddEquipmentCommand>
    {
        private readonly TimesheetReportContext timesheetReportContext;

        public AddEquipmentCommandHandler(TimesheetReportContext timesheetReportContext)
        {
            this.timesheetReportContext = timesheetReportContext;
        }

        protected override void HandleCore(AddEquipmentCommand command)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                var addEquipment = AddEquipment(command);
                if(command.File != null)
                {
                    var fileId = AddIcon(command.File);
                    addEquipment.ImageId = fileId;
                    timesheetReportContext.SaveChanges();
                }
                else
                {
                    timesheetReportContext.SaveChanges();
                }
                transaction.Complete();

            }
        }

        private Guid AddIcon(File file)
        {
            file = timesheetReportContext.Set<File>().Add(file);
            timesheetReportContext.SaveChanges();
            return file.Id;
        }

        public Equipment AddEquipment(AddEquipmentCommand command)
        {
            var newEquiment = new Equipment
            {
                Name = command.Name,
                Code = command.Code,
                AssignOn = DateTime.UtcNow,
                CreatedBy = command.UserName,
                CreatedOn = DateTime.UtcNow,
                ModifiedOn = DateTime.UtcNow,
                Desciption = command.Description
                
            };

            timesheetReportContext.Set<Equipment>()
                .Add(newEquiment);
            return newEquiment;
        }
    }
}
