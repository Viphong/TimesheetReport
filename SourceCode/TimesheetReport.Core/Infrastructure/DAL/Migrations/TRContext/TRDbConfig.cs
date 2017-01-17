using System.Data.Entity.Migrations;

namespace TimesheetReport.Core.Infrastructure.DAL.Migrations.TRContext
{
    internal sealed class TRDbConfig : DbMigrationsConfiguration<TimesheetReportContext>
    {
        public TRDbConfig()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Infrastructure\DAL\Migrations\TRContext";
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TimesheetReportContext context)
        {
        }
    }
}