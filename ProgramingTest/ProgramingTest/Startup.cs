using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProgramingTest.Startup))]
namespace ProgramingTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
