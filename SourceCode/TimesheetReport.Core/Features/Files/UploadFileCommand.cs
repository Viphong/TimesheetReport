using MediatR;

namespace TimesheetReport.Core.Features.Files
{
    public class UploadFileCommand : IRequest<string>
    {
        public File File { get; set; }
    }
}
