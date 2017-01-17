namespace TimesheetReport.Core.Infrastructure.DAL.Migrations.UserContext
{
    using System.Data.Entity.Migrations;

    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Auth.AspNetRoles",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    Name = c.String(nullable: false, maxLength: 256),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");

            CreateTable(
                "Auth.AspNetUserRoles",
                c => new
                {
                    UserId = c.String(nullable: false, maxLength: 128),
                    RoleId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("Auth.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("Auth.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);

            CreateTable(
                "Auth.AspNetUsers",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    Status = c.Int(nullable: false),
                    Email = c.String(maxLength: 256),
                    EmailConfirmed = c.Boolean(nullable: false),
                    PasswordHash = c.String(),
                    SecurityStamp = c.String(),
                    PhoneNumber = c.String(),
                    PhoneNumberConfirmed = c.Boolean(nullable: false),
                    TwoFactorEnabled = c.Boolean(nullable: false),
                    LockoutEndDateUtc = c.DateTime(),
                    LockoutEnabled = c.Boolean(nullable: false),
                    AccessFailedCount = c.Int(nullable: false),
                    UserName = c.String(nullable: false, maxLength: 256),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");

            CreateTable(
                "Auth.AspNetUserClaims",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    UserId = c.String(nullable: false, maxLength: 128),
                    ClaimType = c.String(),
                    ClaimValue = c.String(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Auth.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

            CreateTable(
                "Auth.AspNetUserLogins",
                c => new
                {
                    LoginProvider = c.String(nullable: false, maxLength: 128),
                    ProviderKey = c.String(nullable: false, maxLength: 128),
                    UserId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("Auth.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
        }

        public override void Down()
        {
            DropForeignKey("Auth.AspNetUserRoles", "UserId", "Auth.AspNetUsers");
            DropForeignKey("Auth.AspNetUserLogins", "UserId", "Auth.AspNetUsers");
            DropForeignKey("Auth.AspNetUserClaims", "UserId", "Auth.AspNetUsers");
            DropForeignKey("Auth.AspNetUserRoles", "RoleId", "Auth.AspNetRoles");
            DropIndex("Auth.AspNetUserLogins", new[] { "UserId" });
            DropIndex("Auth.AspNetUserClaims", new[] { "UserId" });
            DropIndex("Auth.AspNetUsers", "UserNameIndex");
            DropIndex("Auth.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("Auth.AspNetUserRoles", new[] { "UserId" });
            DropIndex("Auth.AspNetRoles", "RoleNameIndex");
            DropTable("Auth.AspNetUserLogins");
            DropTable("Auth.AspNetUserClaims");
            DropTable("Auth.AspNetUsers");
            DropTable("Auth.AspNetUserRoles");
            DropTable("Auth.AspNetRoles");
        }
    }
}