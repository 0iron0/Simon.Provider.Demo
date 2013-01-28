using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simon.Provider.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogger log = new Logger();
            log.Write("Hello World.");

            Console.ReadKey();
        }
    }
}
