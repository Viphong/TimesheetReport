using MediatR;

namespace TimesheetReport.Core.Features
{
    public class GetUserFullNameQuery: IRequest<string>
    {
        public string UserId { get; set; }
    }
}
