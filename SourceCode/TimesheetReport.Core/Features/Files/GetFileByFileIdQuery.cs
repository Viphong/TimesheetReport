using MediatR;
using System;

namespace TimesheetReport.Core.Features.Files
{
    public class GetFileByFileIdQuery : IRequest<File>
    {
        public Guid FileId { get; set; }
    }
}
