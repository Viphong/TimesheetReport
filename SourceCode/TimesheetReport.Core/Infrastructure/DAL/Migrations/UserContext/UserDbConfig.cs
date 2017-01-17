namespace TimesheetReport.Core.Infrastructure.DAL.Migrations.UserContext
{
    using Features.TRUsers;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity.Migrations;

    internal sealed class UserDbConfig : DbMigrationsConfiguration<ManageUsersDbContext>
    {
        public UserDbConfig()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Infrastructure\DAL\Migrations\UserContext";
        }

        protected override void Seed(ManageUsersDbContext context)
        {
            SeedRoles(context);
        }

        private void SeedRoles(ManageUsersDbContext context)
        {
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            if (!roleManager.RoleExists(UserRoles.Admin))
            {
                IdentityRole newRole = new IdentityRole(UserRoles.Admin);
                roleManager.Create(newRole);
            }

            if (!roleManager.RoleExists(UserRoles.Staff))
            {
                IdentityRole newRole = new IdentityRole(UserRoles.Staff);
                roleManager.Create(newRole);
            }
        }
    }
}
