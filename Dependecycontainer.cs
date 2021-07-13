using _23haziran_web.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _23haziran_web
{
    public class Dependecycontainer
    {
        //ctor constructor
        public Dependecycontainer()
        {
            IServiceCollection services = new ServiceCollection();//built - in IoC
            services.Add(new ServiceDescriptor(typeof(ConsoleLog),new ConsoleLog(5)));
            services.Add(new ServiceDescriptor(typeof(TextLog), new TextLog()));
            ServiceProvider provider = services.BuildServiceProvider(); //somut container provider sağlayıcı
            provider.GetServices<ConsoleLog>();
            provider.GetService<TextLog>();
        }
        
    }
}
