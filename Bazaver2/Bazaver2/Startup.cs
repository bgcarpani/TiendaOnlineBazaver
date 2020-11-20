using System;
using Bazaver2.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bazaver2.Startup))]
namespace Bazaver2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            ConfigureAuth(app);
         
        }

       
    }
}
