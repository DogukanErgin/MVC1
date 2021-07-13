using _23haziran_web.Models;
using _23haziran_web.Services;
using _23haziran_web.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
#region Action Türleri anlatım
//'viewResult' response olarak bir view dosyasını(.cshtml) render etmemizi  sağlayan action türüdür.

//'PartialviewResult' viewresult ile aynıdır temel farkı client tabanlı yapılan ajax isteklerinde kullanıma yatkındır nedir bu ajax websitesine girip işlem yaptığında
//sayfayı yenilemeden sitenin belirli bir kısmında yaptığımız işlemlerin sonucu geliyorsa bu ajax teknolojisidir
//viewresult viewstart.cshtml dosyasını baz alır. Lakin partialviewResult ise ilgili dosyayı baz almadan render edilir

//'jsonresult' json türüne dönüştürüp döndürür

//'emptyresult' bazen gelen istekler neticesinde herhangi bir şey döndürmek istemeyebiliriz.Böyle bir durumda EmptyResult action türü tercih edilir.

//contentresult istek neticesinde cevap olarak metinsel bir değer döndürmemizi sağlayan action türüdür

//actionresult gelen bir istek neticesinde geriye döndürülecek action türleri değişkenlik gösterebildiği durumlarda kullanıldığı bir action türüdür

//controller içerisinde NonAction Attribute'u ile işaretlenen fonksiyonlar dışarıdan request karsılamazlar 
//sadece operatif yani algoritma barındıran/is mantigi yürüten bir metottur.
//NonController web sayfasına product/farketmez her hangi bir şey çağrılamaz çünkü kapatılmış olur 

#endregion
namespace _23haziran_web.Controllers //controller ken çalışmaz çünkü inherit kalıtım yapamaz 
{
  //  [Route("ana")]
    public class ProductController : Controller
    {
        public ILog Log { get; } //yerine
        readonly ILog _log;


        //public IActionResult GetProducts() result türleri
        // {
        //     Product product = new Product(); //controllerdan modele gittik neticesini elde ettik

        //     ViewResult result = View("GetProducts"); //viewden controllara gönderilen sonuçlar
        //                              //esneklik sağlar aksiyon metotun ismi aynı olmasa bile başka bir cshtml belirtebilirim 
        //     //return View();
        //     return result; //controller tarafından client e gönderilen
        // }
        //public JsonResult GetProducts()
        //    {
        //       JsonResult result= Json(new Product
        //        {
        //            Id = 5,
        //            ProductName = "Terlik",
        //            Quantity = 10
        //        });
        //        return result;
        //    }
        //public EmptyResult GetProducts()
        //    {
        //        //EmptyResult result = new EmptyResult();
        //        //return result;
        //        return new EmptyResult();
        //    }
        //public ContentResult GetProducts()
        //{
        //    ContentResult result = Content("delirme haydi sen de söyle");
        //    return result;
        //}

        //public ActionResult GetProducts()
        //{
        //    //if else ler ile birden fazla türü bu aksiyon sayesinde birleştirebiliriz mesela bir if te json bir if te content döndürmesi yapabiliriz
        //    //base classtır aksiyon türlerinin atasıdır.       
        //    if (true)
        //    {
        //        return Json(new object());

        //    }
        //    else if (true)
        //    {
        //        return (Content("wrewfsdgf"));

        //    }
        //    return View();
        //}
        //public IActionResult GetProducts()
        //{
        //    //action result ın bir interface idir arayüzüdür. polymorphism kuralları ile işlem sağlamak için kullanılır.
        //}



        //public IActionResult GetProducts()
        //{
        //    X();
        //    return View();
        //}
        //[NonAction]         //controller içerisinde NonAction Attribute'u ile işaretlenen fonksiyonlar dışarıdan request karsılamazlar 
        //                    //sadece operatif yani algoritma barındıran/is mantigi yürüten bir metottur.
        //  public void X()
        //{

        //}

        public IActionResult AnaSayfa()  //4 farklı şekilde controllerdan view e veri gönderilebilir 1.si model bazlı(bununla kullanıcıdan veri alınabilir) diğer 3 ü veri taşıma kontrolleri ile göndermektir.
        {
            #region product nesne listesi
            //List<Product> 
            //var  değişkeni ile de üretilebilir
            //var products = new List<Product>
            // {
            //     new Product {Id=1,ProductName="A product",Quantity=10 },
            //     new Product {Id=2,ProductName="B product",Quantity=15 },
            //     new Product {Id=3,ProductName="C product",Quantity=20 }
            // };
            #endregion

            #region  1-MODEL BAZLI 


            //  return View(products);

            #endregion
            #region        2-VERİ TAŞIMA (VİEWBAG)
            //View' e gönderilecek datayı dynamic şekilde tanımlanan bir değişkenle taşımamızı sağlayan bir veri taşıma kontrolüdür.
            //  ViewBag.dogukan = products;
            // return View();
            #endregion
            #region        3-VERİ TAŞIMA (VİEWDATA)
            //viewdata boxing eder yani view kısmında unbox yapıp kullanman gerekir
            //  ViewData["dogukan"] = products;
            //  return View();
            #endregion
            #region        4-VERİ TAŞIMA (TEMPDATA)
            //bu da boxing eder cookie üzerinden veriyi taşır yani action çalışırken araya farklı bir actionu redirect yaptırırsak diğer yöntemlerle veriyi taşıyamayız

            //bir nesne, bir koleksiyon kullandığında  anasayfa2 yerinde hata verir Serilize etmemiz gerekir bunun için kütüphane kullanabiliriz 

            //string data = JsonSerializer.Serialize(products);
            //TempData["products"] = data;

            //return RedirectToAction("AnaSayfa2", "Home");

            //public IActionResult AnaSayfa2()
            //{

            //    var data = TempData["products"].ToString();
            //    List<Product> products = JsonSerializer.Deserialize<List<Product>>(data);

            //    ViewBag.keko = products;
            //    return View();
                //}
                #endregion

                #region Tuple nesne semantiği
                // https://www.youtube.com/watch?v=nb7DzN9tCZM&list=PLQVXoXFVVtp33KHoTkWklAo72l5bcjPVL&index=18

                #endregion

                return View();

        }
      //  [Route("in")]
        public IActionResult GetProductss()
        {


            #region Html.Partial
            //hedef view' i render etmemizi sağlayan bir fonksiyondur. String döndürür.
            //render edilen view ile ilgili actiondan model/data gönderilebilmektedir.
            // @Html.Partial("~(alt+126)/Views/Product/Partial/ListPartial.cshtml
            //  ViewBag.mesaj = "Controller dan girildim";
            // eğer ki getproducts action'una yanı buraya bir model nesnesi gönderirsek bu nesneyi partiallist'te de kullanabiliriz ama eğer ki html.partial'in
            //son kısmına model ataması yaparsak buraya başka bir model nesnesi gönderemeyiz
            #endregion
            #region Html.RenderPartial
            //bu da aynı işi yapar farkı ise partial razor da direkt kullanılırken renderpartial ise SCOPE içinde kullanılmak zorundadır'' @{} '' bu void döndürür 
            #endregion
            #region Html.ActionLink
            //@Html.ActionLink("Anasayfa","Index","Home")
            #endregion
            #region Html.Helpers 
            // bunlar maaliyetlidir performansı kötüdür .Net Core MVC de Tag Helper kullanmak daha efektif daha performanslıdır
            #endregion


            return View();
        }

        #region NonModelBinding


        //public IActionResult CreateProduct(String txtProductName,int txtQuantity)  //post ise bu tetiklenir //request neticesinde gelen dataların hepsi parametrelerden yakalanır
        //ancak böyle yapmak çok anlamsız çünkü her gelecek veri için tür falan tanımlıyoruz bunun yerine MODEL BİNDİNG yapmamız en doğrusu
        //bunu da entitiy / model im varsa yapabilirim o da product model sınıfım  bu tanıma uyuyor.
        #endregion
        public IActionResult CreateProduct()  //get ise bu tetiklenir
        {
            //bunu yapmamızın sebebi eğer ki bu kodsuz çalıştırıp post ile veri alırsak o veriler yeni bir nesne olarak alınır ancak bu şekilde biz bir nesne
            //tanımlayıp o nesneye bu bilgileri doldurmuş oluruz
            // var product = new Product()
            // {
            //     ProductName = "B product",
            //    Quantity = 18,
            //    Id = 3

            //};
          //  return View(product);
            return View();

        }

        [HttpPost]
        public IActionResult CreateProduct(Product product) //model bindingi sistem yaptı VALİDATİON EKLENDİ 
        {
            //ModelState: MVC'de bir type'ın data annotationslarının durumunu kontrol eden ve geriye sonuç dönen bir property.

            //bu validation işlemi sunucu içindir bunu client'e de eklemek için 3 kütüphane(jquery) kullandık
            if (!ModelState.IsValid)
            {
                //loglama 
                //kullanıcı bilgilendirme
                //    ViewBag.hatamesaj = ModelState.Values.FirstOrDefault().Errors[0].ErrorMessage; //bu patlar çünkü hata olan olmayan karışık şekilde 0. indexi alıyor
                //ViewBag.hatamesaj = ModelState.Values.FirstOrDefault(x=>x.ValidationState==Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid).Errors[0].ErrorMessage;
                //var messages = ModelState.ToList();
                return View(product);               
            }

            //gelen veriler işlem/operasyon/algoritma tabii tutulur 

            return View();
        }
        
        #region VeriAlmaYöntemleri

      
        public IActionResult VeriAlmaYöntemleri1() //FORM post ve get olarak alınır
        {
            return View();
        }
        [HttpPost]
        public IActionResult VeriAlmaYöntemleri1(IFormCollection data) //formdan gelen değerler parametre ile tutulur bunun da birden fazla yöntemi vardır
        {
            var value1 = data["data1"];
            var value2 = data["data2"];

            return View();
        }
        public IActionResult VeriAlmaYöntemleri2(String a, String b) //Query String url üzerinde taşınır sunucuya hızlı bir şekilde veya servise hızlı bir şekilde gönderirir 
                                                                     //güvenlik gerektirmeyen veriler bu yöntemle işlenir
        {                                         //yapılan requestin türü her ne olursa olsun querystring verileri taşınabilir
            return View();                         // product/verialmayöntemleri2?a=5&b=ahmet
        }
        public IActionResult VeriAlmaYöntemleri21()
        {
            //HttpContext.Request
            var QueryString = Request.QueryString; //Request yapılan  endpoint'e query string parametresi eklenmiş mi eklenmemiş mi bununla ilgili bilgi verir.
            var a = Request.Query["a"].ToString();//bunlar koleksiyondur yani index olarak içinden çekmen lazım
            var b = Request.Query["b"].ToString();
            return View();
        }
        public IActionResult VeriAlmaYöntemleri22(Product product)
        {
            return View();
        }

        public IActionResult VeriAlmaYöntemleri3(String id, string a, string b) //aynı şekilde model binding yani class oluşturup o class ve değer vererek oluşturabiliriz
                                                                                //object boxing yapar ilgili değeri göstermez(breakpoint) 
                                                                                //Route parametreleri ile QueryString şu şekildedir /verialmayöntemleri2?a=terlik route ise verialmayöntemleri3/terlik
        {
            var values = Request.RouteValues;
            return View();
        }
        public IActionResult VeriAlmaYöntemleri4() //header ile veri alma sadece latin alfabesi kullanılır
        {
            var headers = Request.Headers;
            return View();
      }

        public class AjaxData
        {
            public string A { get; set; }
            public string B { get; set; }

        }
        public IActionResult VeriAlmaYöntemleri5()
        {
            return View();
        }
        [HttpPost]
        public IActionResult VeriAlmaYöntemleri5(AjaxData ajaxData) // ajax : istemci(client) tabanlı UI  lazım veri göndermek ve sonucunu görmek için kullanılır
        //burada bir sorun yaşamıştım neydi bu sorun view döndürmeye çalıştığım yerde veri göndermeye çalışıyordum
        {
            return View();
        }

        #endregion
        //ctor
        public ProductController(ILog log)
        { //log'u property yap
            _log = log;
        }
        public IActionResult Index()
        {
            //ConsoleLog Log = new ConsoleLog(5);
            //Log.Log();
            _log.Log(); //controller bazlı

            return View(); 
             //model bazlı gönderim
        }
        public IActionResult Sayfa1([FromServices]ILog log) //action bazlı
        {
            _log.Log();
                return View();
            }
        public IActionResult Sayfa2()
        {

           

            return View();
        }
    }
}
