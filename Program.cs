using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _23haziran_web //asp kendi sunucusunu bulundurur burası console kısmıdır temelinde konsoldan ayağa kaldırılır
{
    public class Program //ayağa kaldıracak hostun, configurasyonlarının belirtildiği alan
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        // kestel i ayağa kaldırmak için fonksiyon
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>(); //startup konfigürasyonlarını kullan 
                });
    }
}
