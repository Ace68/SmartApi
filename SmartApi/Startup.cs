﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(SmartApi.Startup))]

namespace SmartApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
