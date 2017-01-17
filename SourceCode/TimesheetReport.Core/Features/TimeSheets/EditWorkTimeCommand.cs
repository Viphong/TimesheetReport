using MediatR;
using System;

namespace TimesheetReport.Core.Features.TimeSheets
{
    public class EditWorkTimeCommand : IRequest<string>
    {
        public Guid Id { get; set; }

        public Guid ProjectId { get; set; }

        public double Hours { get; set; }

        public string Tasks { get; set; }
    }
}