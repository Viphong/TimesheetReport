namespace TimesheetReport.Core.Infrastructure.DAL.Migrations.TRContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFileTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "TR.Files",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Length = c.Int(nullable: false),
                        Name = c.String(),
                        Data = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("TR.Files");
        }
    }
}
