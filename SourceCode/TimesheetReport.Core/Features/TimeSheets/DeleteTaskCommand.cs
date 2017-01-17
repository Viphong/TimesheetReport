using MediatR;
using System;

namespace TimesheetReport.Core.Features.TimeSheets
{
    public class DeleteTaskCommand : IRequest<string>
    {
        public Guid TaskId { get; set; }
    }
}