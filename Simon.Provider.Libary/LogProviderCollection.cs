using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration.Provider;

namespace Simon.Provider.Library
{
    public class LogProviderCollection : ProviderCollection
    {
        public override void Add(ProviderBase provider)
        {
            if (!(provider is LogProviderBase))
            {
                throw new ArgumentException("the provider is not log provider.");
            }
            base.Add(provider);
        }

        new public LogProviderBase this[string name]
        {
            get
            {
                return base[name] as LogProviderBase;
            }
        }
    }
}
