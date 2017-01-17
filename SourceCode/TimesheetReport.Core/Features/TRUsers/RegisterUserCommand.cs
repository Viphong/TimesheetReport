using MediatR;
using System;

namespace TimesheetReport.Core.Features.TRUsers
{
    public class RegisterUserCommand : IRequest<TRUser>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public Genders Genders { get; set; }

        public string EnglishName { get; set; }

        public DateTime DOB { get; set; }

        public string IdNumber { get; set; }

        public Guid AvartarId { get; set; }
    }
}
