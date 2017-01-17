namespace TimesheetReport.Core.Infrastructure.DAL.Migrations.TRContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEquipment4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("TR.Equipments", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("TR.Equipments", "Status");
        }
    }
}
