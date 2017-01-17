using MediatR;
using System;
using System.Collections.Generic;

namespace TimesheetReport.Core.Features.TimeSheets
{
    public class AddWorkTimeCommand : IRequest<WorkTime>
    {
        public string UserId { get; set; }

        public Guid ProjectId { get; set; }

        public string Tasks { get; set; }

        public double Hours { get; set; }

        public DateTime AddedDate { get; set; }
    }
}