namespace TimesheetReport.Core.Infrastructure.DAL.Migrations.TRContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEquipment2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("TR.Equipments", "ImageId", c => c.Guid());
            AddColumn("TR.Equipments", "CreatedBy", c => c.String());
            AddColumn("TR.Equipments", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("TR.Equipments", "Modified", c => c.String());
            AddColumn("TR.Equipments", "ModifiedOn", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("TR.Equipments", "ModifiedOn");
            DropColumn("TR.Equipments", "Modified");
            DropColumn("TR.Equipments", "CreatedOn");
            DropColumn("TR.Equipments", "CreatedBy");
            DropColumn("TR.Equipments", "ImageId");
        }
    }
}
