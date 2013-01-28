using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Simon.Provider.Library
{
    public class LogProviderConfiguration : ConfigurationSection
    {
        [ConfigurationProperty("defaultProvider", IsRequired = true)]
        public string DefaultProvider
        {
            get
            {
                return base["defaultProvider"] as string;
            }
        }

        [ConfigurationProperty("providers", IsDefaultCollection = true)]
        public ProviderSettingsCollection Providers
        {
            get
            {
                return base["providers"] as ProviderSettingsCollection;
            }
        }
    }
}
