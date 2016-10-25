using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Transaction.Presentation.MVC.Startup))]
namespace Transaction.Presentation.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
