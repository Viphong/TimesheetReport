namespace TimesheetReport.Core.Infrastructure.DAL.Migrations.TRContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEquipment3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("TR.Equipments", "Desciption", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("TR.Equipments", "Desciption");
        }
    }
}
