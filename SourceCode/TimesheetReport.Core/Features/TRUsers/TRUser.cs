using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace TimesheetReport.Core.Features.TRUsers
{
    public class TRUser : IdentityUser
    {
        public int Status { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EnglishName { get; set; }

        public DateTime DOB { get; set; }

        public Genders Gender { get; set; }

        public string IdNumber { get; set; }

        public int Position { get; set; }

        public DateTime? StartDate { get; set; }

        public Guid AvartarId { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<TRUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<TRUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }

        public void UpdateStatus(UserStatus status)
        {
            Status = (int)status;
        }
    }

    public enum UserStatus
    {
        Pending,
        Rejected,
        Active,
        Inactive
    }

    // Remain two value due to parsing to boolean
    public enum Genders
    {
        Male = 0,
        Female = 1
    }
}