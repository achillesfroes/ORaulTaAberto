using Owin;
using Microsoft.Owin;

[assembly: OwinStartup(typeof(WebApplication4.Startup))]
namespace WebApplication4
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Any connection or hub wire up and configuration should go here
            app.MapSignalR();
        }
    }
}