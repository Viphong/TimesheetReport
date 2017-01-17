using MediatR;

namespace TimesheetReport.Core.Features.TRUsers
{
    public class GetProfileUserQuerry:IRequest<TRUser>
    {
        public string UserId { get; set; }
    }
}
