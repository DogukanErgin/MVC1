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
       
        public void ConfigureServices(IServiceCollection services) //servis(belirli iþlere odaklanmýþ ve o iþin sorumluluðunu üstlenmiþ kütüphaneler sýnýflar vb servis=modül=kütüphane) konfigürasyonu
        {                                                          //dependency injection konteynýrý iþte bu parametredir.
                                                                   //model, servis deðil katmandýr
            #region dependecy injection
            //services.Add(new ServiceDescriptor(typeof(ConsoleLog), new ConsoleLog()));
            //services.Add(new ServiceDescriptor(typeof(TextLog), new TextLog())); //default olarak singletondur
            //services.Add(new ServiceDescriptor(typeof(TextLog), new TextLog(),ServiceLifetime.Transient));
            //services.AddSingleton<ConsoleLog>(); //parametre almýyorsa olur
            //services.AddSingleton<TextLog>();
            //services.AddSingleton<TextLog>(); 
            //services.AddSingleton<ConsoleLog>(p=> new ConsoleLog(5)); 
            //services.AddScoped<ConsoleLog>(p => new ConsoleLog(5));
            //services.AddTransient<ConsoleLog>(p => new ConsoleLog(5));
          
            // services.AddScoped<ILog, TextLog>();

            services.AddScoped<ILog>(p => new ConsoleLog(5));

            //services.AddScoped<ILog>(p => new TextLog()); textloga a döndürdük
            #endregion

            services.AddControllersWithViews();
            services.AddRazorPages(); 

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) //middleware lar çaðrýlýr
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            #region Middleware

            ////middlewareler use ile baþlar ve sýralama önemlidir sarmal yapýdadýr [[[]]] 
            #region Run metodu
            // Run fonksiyonu kendisinden sonra gelen  middlewareyi tetiklemez , dolayýsýyla kullanýldýðý yerden  sonraki middlewareler tetiklenmeyeceðinden
            //dolayý akýþ kesilir bu etkiye short circuit (kýsa devre) denir

            #endregion
            #region use metodu
            // run metoduna nazaran, devreye girdikten sonraki süreçte sýradaki middlewareyi çaðýrmakta ve normal middleware  iþlevi bittikten sonra  geriye dönüp
            // devam edebilen bir yapýya sahiptir
            #endregion
            #region Map metodu
            //bazen middleware'i talep gönderen path e göre filtrelemek isteyebilriiz. Bunun için use ya da run fonksiyonlarýnda if kontrolu saðlayabilir
            //yahut map metodu ile daha profesyonel iþlem yapabiliriz.
            #endregion
            #region MapWhen metodu
            // map metodu ile sadece request'in yapýldýðý path' e göre filtreleme yapýlýrken, MapWhen metodu ile gelen request'in herhangi bir özelliðine
            //göre bir filtreleme iþlemi gerçekleþtirebilir.
            #endregion
            #endregion

            #region Middleware

            //app.Use(async (context, next) => {
            //    Console.WriteLine("Start use Middleware");
            //   await next.Invoke();  //burasý kendinden sonra gelen middleware ' i tetiklemek için mutlaka gereklidir
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


            app.UseStaticFiles();   //wwwroot kullanmak için gerekli

             app.UseRouting(); //rotalandýrma iþlemi

            //endpoint varýþ noktasý istek yapýlacak adresi temsil eder(url , istek adresi)
            app.UseEndpoints(endpoints =>
            {
                //özelden genele sýrala
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
                //constraints iþlemi
                //endpoints.MapDefaultControllerRoute();

                //{controller=Home}/{action=Index}/{id?} defaulttur
                //endpoint tanýmlamasýnda süslü parantez içerisinde parametre 
                //tanýmlanabilmektedir.Bu Parametreler herhangi bir isimde olabilir
                //
                #region CustomRouteHandler


                //endpoints.Map("example-route", async c =>
                // {
                // https://localhost:5001/example-route endpoint'e gelen her hangi bir istek controller'dan ziyade direkt olarak buradaki fonksiyon
                //    tarafýndan karþýlanacaktýr.

                // });
                endpoints.Map("image/{imageName}",new ImageHandler().Handler(env.WebRootPath));
                endpoints.Map("example-route", new ExampleHandler().Handler());

                #endregion



            });
         

        }
    }
}
