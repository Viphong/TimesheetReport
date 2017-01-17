namespace TimesheetReport.Core.Infrastructure.DAL.Migrations.UserContext
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddGender : DbMigration
    {
        public override void Up()
        {
            AddColumn("Auth.AspNetUsers", "Gender", c => c.Int(nullable: false));
            AlterColumn("Auth.AspNetUsers", "DOB", c => c.DateTime(nullable: false));
        }

        public override void Down()
        {
            AddColumn("Auth.AspNetUsers", "Genders", c => c.Int(nullable: false));
            AlterColumn("Auth.AspNetUsers", "DOB", c => c.DateTime());
            DropColumn("Auth.AspNetUsers", "Gender");
        }
    }
}