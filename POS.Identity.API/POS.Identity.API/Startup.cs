using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(POS.API.Startup))]

namespace POS.API
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
          
         app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            ConfigureAuth(app);
        }
    }
}
