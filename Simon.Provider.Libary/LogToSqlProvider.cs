using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Configuration.Provider;

namespace Simon.Provider.Library
{
    public class LogToSqlProvider : LogProviderBase
    {
        public override void Initialize(string name, NameValueCollection config)
        {
            if (config == null || config.Count == 0)
            {
                throw new ArgumentNullException("you must supply a valid provider.");
            }

            base.Initialize(name, config);

            ////process other configuration properties
            //this.mName = name;

            //string description = config["description"];
            //if (string.IsNullOrEmpty(description))
            //{
            //    throw new ProviderException("you must specify a valid description attribue.");
            //}
            //this.mDescription = description;
        }

        public override void Write(string message)//impelement provider method
        {
            Console.WriteLine("I am a provider for logging to sql, output message is: {0}", message);
        }
    }
}
