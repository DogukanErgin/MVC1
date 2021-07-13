using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _23haziran_web.Handlers //delagate
{
    public class ExampleHandler
    {
        public RequestDelegate Handler() //resim boyutlandırma yaparız neden html ile yaparsak 10 boyutlu resim küçük şekilde gözükür ama yine 10 boyuttur
        {                                //bu şekilde sunucuda tarafında boyutu da küçülterek kullanıcıya gösteririrz

            return async c => {
                await c.Response.WriteAsync("selams");
             
            };
        }
    }
}
