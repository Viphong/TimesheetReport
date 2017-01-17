using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TimesheetReport.WebUI.Startup))]

namespace TimesheetReport.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureCompositionRoot(app);
            ConfigureAuth(app);
        }
    }
}