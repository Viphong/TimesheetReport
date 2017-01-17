using Microsoft.AspNet.Identity.EntityFramework;
using TimesheetReport.Core.Features.TRUsers;
using System.Data.Entity;

namespace TimesheetReport.Core.Infrastructure.DAL
{
    public class ManageUsersDbContext : IdentityDbContext<TRUser>
    {
        public ManageUsersDbContext()
            : base("Name=TimesheetReportContext")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Auth");

            Database.SetInitializer<ManageUsersDbContext>(null);

            base.OnModelCreating(modelBuilder);
        }

        public static ManageUsersDbContext Create()
        {
            return new ManageUsersDbContext();
        }
    }
}