using _23haziran_web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _23haziran_web.Services
{
    public class ConsoleLog :ILog
    {
        //ctor
        public ConsoleLog(int a)
        {

        }
        public void Log() {
            Console.WriteLine("Console loglama işlemi gerçekleştirildi....");
        }
    }
}
