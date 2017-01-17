namespace TimesheetReport.Core.Infrastructure.DAL.Migrations.TRContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedProjectModelChangeAvatarIdToIconId : DbMigration
    {
        public override void Up()
        {
            RenameColumn("TR.Projects", "AvatarId", "IconId");
        }
        
        public override void Down()
        {
            RenameColumn("TR.Projects", "IconId", "AvatarId");
        }
    }
}
