namespace TimesheetReport.Core.Infrastructure.DAL.Migrations.TRContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProjectAndWorkTime : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "TR.Projects",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        ClientName = c.String(),
                        Status = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        AvatarId = c.Guid(nullable: false),
                        ProjectOwner = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "TR.WorkTimes",
                c => new
                    {
                        TimeId = c.Guid(nullable: false),
                        ProjectId = c.Guid(nullable: false),
                        EmployeeId = c.String(),
                        Task = c.String(),
                        Hours = c.Double(nullable: false),
                        Time = c.DateTime(),
                    })
                .PrimaryKey(t => t.TimeId);
            
        }
        
        public override void Down()
        {
            DropTable("TR.WorkTimes");
            DropTable("TR.Projects");
        }
    }
}
