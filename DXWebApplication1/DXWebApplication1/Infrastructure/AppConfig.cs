using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace DXWebApplication1.Infrastructure
{
    public class AppConfig
    {
        public static int CacheExpirationDays
        {
            get
            {
                return Convert.ToInt32(WebConfigurationManager.AppSettings["CacheExpirationDays"]);
            }
        }

        public static bool IsCacheSlidingExpiration
        {
            get
            {
                return Convert.ToBoolean(WebConfigurationManager.AppSettings["IsCacheSlidingExpiration"]);
            }
        }
    }
}