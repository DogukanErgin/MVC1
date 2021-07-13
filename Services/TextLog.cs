using _23haziran_web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _23haziran_web.Services
{
    public class TextLog :ILog
    {
        public void Log()
        {
            Console.WriteLine("text loglama işlemi gerçekleştirildi....");
        }
    }
}
