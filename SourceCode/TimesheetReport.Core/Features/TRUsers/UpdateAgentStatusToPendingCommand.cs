using MediatR;

namespace TimesheetReport.Core.Features.TRUsers
{
    public class UpdateAgentStatusToPendingCommand : IRequest
    {
        public string UserId { get; set; }

        public UserStatus Status { get; set; }
    }
}