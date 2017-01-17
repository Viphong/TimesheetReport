namespace TimesheetReport.Core.Infrastructure.DAL.Migrations.TRContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEquipment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "TR.Equipments",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Code = c.String(),
                        AssignOn = c.DateTime(nullable: false),
                        AssignBy = c.String(),
                        AssignTo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("TR.Equipments");
        }
    }
}
