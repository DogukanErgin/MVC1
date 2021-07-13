using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _23haziran_web //asp kendi sunucusunu bulundurur buras� console k�sm�d�r temelinde konsoldan aya�a kald�r�l�r
{
    public class Program //aya�a kald�racak hostun, configurasyonlar�n�n belirtildi�i alan
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        // kestel i aya�a kald�rmak i�in fonksiyon
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>(); //startup konfig�rasyonlar�n� kullan 
                });
    }
}
