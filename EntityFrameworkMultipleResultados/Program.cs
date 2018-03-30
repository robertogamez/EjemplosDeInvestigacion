using EntityFrameworkMultipleResultados.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkMultipleResultados
{
    class Program
    {
        static void Main(string[] args)
        {
            LogsBLL logsBll = new LogsBLL();

            LogInfoEntity logInfoResult = logsBll.GetLogInfo();

            Console.ReadLine();
        }
    }
}
