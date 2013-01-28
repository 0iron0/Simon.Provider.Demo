using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simon.Provider.Library;

namespace Simon.Provider.Demo
{
    interface ILogger
    {
        void Write(string message);
    }
    public class Logger : ILogger
    {
        public void Write(string message)
        {
            Console.WriteLine("default provier name is: {0}", LogProviderManager.DefaultProvider.Name);
            LogProviderManager.DefaultProvider.Write(message);

            foreach (LogProviderBase provider in LogProviderManager.Providers)
            {
                Console.WriteLine("provider name is: {0}", provider.Name);
                provider.Write(message);
            }
        }
    }
}
