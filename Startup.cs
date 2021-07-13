using _23haziran_web.Handlers;
using _23haziran_web.Services;
using _23haziran_web.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _23haziran_web
{
    public class Startup
    {
       
        public void ConfigureServices(IServiceCollection services) //servis(belirli i�lere odaklanm�� ve o i�in sorumlulu�unu �stlenmi� k�t�phaneler s�n�flar vb servis=mod�l=k�t�phane) konfig�rasyonu
        {                                                          //dependency injection konteyn�r� i�te bu parametredir.
                                                                   //model, servis de�il katmand�r
            #region dependecy injection
            //services.Add(new ServiceDescriptor(typeof(ConsoleLog), new ConsoleLog()));
            //services.Add(new ServiceDescriptor(typeof(TextLog), new TextLog())); //default olarak singletondur
            //services.Add(new ServiceDescriptor(typeof(TextLog), new TextLog(),ServiceLifetime.Transient));
            //services.AddSingleton<ConsoleLog>(); //parametre alm�yorsa olur
            //services.AddSingleton<TextLog>();
            //services.AddSingleton<TextLog>(); 
            //services.AddSingleton<ConsoleLog>(p=> new ConsoleLog(5)); 
            //services.AddScoped<ConsoleLog>(p => new ConsoleLog(5));
            //services.AddTransient<ConsoleLog>(p => new ConsoleLog(5));
          
            // services.AddScoped<ILog, TextLog>();

            services.AddScoped<ILog>(p => new ConsoleLog(5));

            //services.AddScoped<ILog>(p => new TextLog()); textloga a d�nd�rd�k
            #endregion

            services.AddControllersWithViews();
            services.AddRazorPages(); 

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) //middleware lar �a�r�l�r
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            #region Middleware

            ////middlewareler use ile ba�lar ve s�ralama �nemlidir sarmal yap�dad�r [[[]]] 
            #region Run metodu
            // Run fonksiyonu kendisinden sonra gelen  middlewareyi tetiklemez , dolay�s�yla kullan�ld��� yerden  sonraki middlewareler tetiklenmeyece�inden
            //dolay� ak�� kesilir bu etkiye short circuit (k�sa devre) denir

            #endregion
            #region use metodu
            // run metoduna nazaran, devreye girdikten sonraki s�re�te s�radaki middlewareyi �a��rmakta ve normal middleware  i�levi bittikten sonra  geriye d�n�p
            // devam edebilen bir yap�ya sahiptir
            #endregion
            #region Map metodu
            //bazen middleware'i talep g�nderen path e g�re filtrelemek isteyebilriiz. Bunun i�in use ya da run fonksiyonlar�nda if kontrolu sa�layabilir
            //yahut map metodu ile daha profesyonel i�lem yapabiliriz.
            #endregion
            #region MapWhen metodu
            // map metodu ile sadece request'in yap�ld��� path' e g�re filtreleme yap�l�rken, MapWhen metodu ile gelen request'in herhangi bir �zelli�ine
            //g�re bir filtreleme i�lemi ger�ekle�tirebilir.
            #endregion
            #endregion

            #region Middleware

            //app.Use(async (context, next) => {
            //    Console.WriteLine("Start use Middleware");
            //   await next.Invoke();  //buras� kendinden sonra gelen middleware ' i tetiklemek i�in mutlaka gereklidir
            //    Console.WriteLine("stop use Middleware");

            //});
            //app.Run(async context => {
            //    Console.WriteLine("Run Middleware");


            //});

            //app.Use(async(context, task) => {
            //    Console.WriteLine("Start use Middleware 1");
            //    await task.Invoke();
            //    Console.WriteLine("Stop use Middleware 1");

             
            //});
            //app.Map("/sayfa1", builder =>
            //{
            //    builder.Run(async c => await c.Response.WriteAsync("Run Middleware tetiklendi"));
            //});
            //app.Map("/home", builder => {
            //    builder.Use(async (context, task) => {
            //        Console.WriteLine("Start use Middleware 2");
            //        await task.Invoke();
            //        Console.WriteLine("Stop use Middleware 2 ");
            //    });
            //});

            //app.MapWhen(c => c.Request.Method == "GET",builder=> {
            //    builder.Use(async (context, task) => {
            //        Console.WriteLine("Start use Middleware 2 ");
            //        await task.Invoke();
            //        Console.WriteLine("Stop use Middleware 2 ");
            //    });
            //});

            #endregion


            app.UseStaticFiles();   //wwwroot kullanmak i�in gerekli

             app.UseRouting(); //rotaland�rma i�lemi

            //endpoint var�� noktas� istek yap�lacak adresi temsil eder(url , istek adresi)
            app.UseEndpoints(endpoints =>
            {
                //�zelden genele s�rala
                endpoints.MapControllerRoute("CustomRoute3", "sayfa1", new { Controller = "Product", action = "sayfa1", id = "?" });
                endpoints.MapControllerRoute("CustomRoute2", "anasayfa", new {Controller="Product",action="Index",id="?" });
                endpoints.MapControllerRoute("CustomRoute", "{controller=Product}/{action=Index}/{a?}/{b?}/{id?}");
               
                endpoints.MapControllerRoute(  //default olarak yani faturapaneli/home/index girmek gerek
                    name:"areaDefault",
                    pattern:"{area:exists}/{Controller=Home}/{Action=Index}/{id?}"
                    );
                //endpoints.MapAreaControllerRoute(
                //    name:"fatura",
                //    areaName:"Fatura_Paneli",
                //    pattern:"admin/{Controller=Home}/{Action=Index}"
                //    );
                //endpoints.MapAreaControllerRoute(
                //   name: "yonetim",
                //   areaName: "Yonetim_Paneli",
                //   pattern: "admin2/{Controller=Home}/{Action=Index}"
                //   );

                // endpoints.MapControllerRoute("CustomRoute","{controller=Product}/{action=Index}/{a?}/{b:length(12)?}/{id:int?}");
                //constraints i�lemi
                //endpoints.MapDefaultControllerRoute();

                //{controller=Home}/{action=Index}/{id?} defaulttur
                //endpoint tan�mlamas�nda s�sl� parantez i�erisinde parametre 
                //tan�mlanabilmektedir.Bu Parametreler herhangi bir isimde olabilir
                //
                #region CustomRouteHandler


                //endpoints.Map("example-route", async c =>
                // {
                // https://localhost:5001/example-route endpoint'e gelen her hangi bir istek controller'dan ziyade direkt olarak buradaki fonksiyon
                //    taraf�ndan kar��lanacakt�r.

                // });
                endpoints.Map("image/{imageName}",new ImageHandler().Handler(env.WebRootPath));
                endpoints.Map("example-route", new ExampleHandler().Handler());

                #endregion



            });
         

        }
    }
}
