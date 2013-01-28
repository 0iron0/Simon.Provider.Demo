using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration.Provider;

namespace Simon.Provider.Library
{
    public abstract class LogProviderBase : ProviderBase
    {
        //protected string mName;
        //protected string mDescription;

        //public override string Name
        //{
        //    get
        //    {
        //        return mName;
        //    }
        //}

        //public override string Description
        //{
        //    get
        //    {
        //        return mDescription;
        //    }
        //}

        //define some abstract actions in the provider
        public abstract void Write(string message);
    }
}
