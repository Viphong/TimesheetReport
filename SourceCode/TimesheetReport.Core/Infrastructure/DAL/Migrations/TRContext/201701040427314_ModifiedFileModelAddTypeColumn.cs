namespace TimesheetReport.Core.Infrastructure.DAL.Migrations.TRContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedFileModelAddTypeColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("TR.Files", "Type", c => c.String());
            AlterColumn("TR.WorkTimes", "Time", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("TR.WorkTimes", "Time", c => c.DateTime());
            DropColumn("TR.Files", "Type");
        }
    }
}
