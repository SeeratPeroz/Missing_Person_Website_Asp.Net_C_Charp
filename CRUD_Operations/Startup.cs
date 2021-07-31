using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CRUD_Operations.Startup))]
namespace CRUD_Operations
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
