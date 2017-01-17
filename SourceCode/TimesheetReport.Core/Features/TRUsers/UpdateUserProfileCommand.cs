using MediatR;
using System;
using TimesheetReport.Core.Features.Files;

namespace TimesheetReport.Core.Features.TRUsers
{
    public class UpdateUserProfileCommand : IRequest<bool>
    {
        public string UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public Genders Gender { get; set; }

        public string EnglishName { get; set; }

        public DateTime DOB { get; set; }

        public string IdNumber { get; set; }

        public File File { get; set; }

    }
}
