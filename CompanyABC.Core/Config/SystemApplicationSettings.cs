using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;

namespace CompanyABC.Core.Config
{
    public class SystemApplicationSettings : IApplicationSettings
    {
        public SystemApplicationSettings()
        {
            AppSettings = ConfigurationManager.AppSettings;
        }

        private NameValueCollection AppSettings { get; set; }

        public string this[String key]
        {
            get { return AppSettings[key]; }
        }
    }
}