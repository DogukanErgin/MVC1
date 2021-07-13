using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _23haziran_web //asp kendi sunucusunu bulundurur burasý console kýsmýdýr temelinde konsoldan ayaða kaldýrýlýr
{
    public class Program //ayaða kaldýracak hostun, configurasyonlarýnýn belirtildiði alan
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        // kestel i ayaða kaldýrmak için fonksiyon
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>(); //startup konfigürasyonlarýný kullan 
                });
    }
}
