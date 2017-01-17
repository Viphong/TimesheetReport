namespace TimesheetReport.Core.Infrastructure.DAL.Migrations.TRContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedProjectsModelIconIdAllowNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("TR.Projects", "IconId", c => c.Guid());
        }
        
        public override void Down()
        {
            AlterColumn("TR.Projects", "IconId", c => c.Guid(nullable: false));
        }
    }
}
