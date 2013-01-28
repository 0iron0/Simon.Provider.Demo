using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Configuration.Provider;
using System.Web.Configuration;

namespace Simon.Provider.Library
{
    public static class LogProviderManager
    {
        private static LogProviderBase mDefaultProvider;
        private static LogProviderCollection mProviders;

        private static bool mIsInitialized = false;
        private static Exception mInitializationException;

        public static LogProviderBase DefaultProvider
        {
            get
            {
                if (!mIsInitialized)
                    Initialize();
                return mDefaultProvider;
            }
        }

        public static LogProviderCollection Providers
        {
            get
            {
                if (!mIsInitialized)
                    Initialize();
                return mProviders;
            }
        }

        static LogProviderManager()
        {
            Initialize();
        }

        /// <summary>
        /// initialize providers
        /// 1. read configuration from app.config
        /// 2. validate configuration
        /// 3. initialize providers
        /// </summary>
        private static void Initialize()
        {
            try
            {
                LogProviderConfiguration config = ConfigurationManager.GetSection("logProvider") as LogProviderConfiguration;
                if (config == null || config.Providers == null || config.Providers.Count == 0)
                {
                    throw new ProviderException("you must specify a valid default provider.");
                }

                mProviders = new LogProviderCollection();
                ProvidersHelper.InstantiateProviders(config.Providers, mProviders, typeof(LogProviderBase));
                mProviders.SetReadOnly();

                mDefaultProvider = mProviders[config.DefaultProvider];
                if (mDefaultProvider == null)
                {
                    throw new ConfigurationErrorsException(
                        "You must specify a default provider for the feature.",
                        config.ElementInformation.Properties["defaultProvider"].Source,
                        config.ElementInformation.Properties["defaultProvider"].LineNumber);
                }
            }
            catch (Exception e)
            {
                mInitializationException = e;
                mIsInitialized = false;
                throw;
            }

            mIsInitialized = true;
        }
    }
}
