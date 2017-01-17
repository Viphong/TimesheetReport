namespace TimesheetReport.Core.Infrastructure.DAL.Migrations.UserContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("Auth.AspNetUsers", "FirstName", c => c.String());
            AddColumn("Auth.AspNetUsers", "LastName", c => c.String());
            AddColumn("Auth.AspNetUsers", "EnglishName", c => c.String());
            AddColumn("Auth.AspNetUsers", "DOB", c => c.DateTime());
            AddColumn("Auth.AspNetUsers", "IDNumber", c => c.String());
            AddColumn("Auth.AspNetUsers", "Position", c => c.Int(nullable: false));
            AddColumn("Auth.AspNetUsers", "StartDate", c => c.DateTime());
            AddColumn("Auth.AspNetUsers", "AvartarID", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("Auth.AspNetUsers", "AvartarID");
            DropColumn("Auth.AspNetUsers", "StartDate");
            DropColumn("Auth.AspNetUsers", "Position");
            DropColumn("Auth.AspNetUsers", "IDNumber");
            DropColumn("Auth.AspNetUsers", "DOB");
            DropColumn("Auth.AspNetUsers", "EnglishName");
            DropColumn("Auth.AspNetUsers", "LastName");
            DropColumn("Auth.AspNetUsers", "FirstName");
        }
    }
}
