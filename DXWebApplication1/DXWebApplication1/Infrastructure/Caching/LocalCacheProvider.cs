using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DXWebApplication1.Infrastructure.Caching
{
    public class LocalCacheProvider : ICache
    {
        public object Get(string key)
        {
            return HttpContext.Current.Cache.Get(key);
        }

        public void Put(string key, object value)
        {
            int expirationDays = AppConfig.CacheExpirationDays;
            if (AppConfig.IsCacheSlidingExpiration)
            {
                HttpContext.Current.Cache.Insert(key, value, null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromDays(expirationDays));
            }
            else
                HttpContext.Current.Cache.Insert(key, value, null, DateTime.UtcNow.AddDays(expirationDays), System.Web.Caching.Cache.NoSlidingExpiration);
        }


        public void Put(string key, object value, double expiration)
        {
            HttpContext.Current.Cache.Insert(key, value, null, DateTime.Now.AddMinutes(expiration), System.Web.Caching.Cache.NoSlidingExpiration);
        }

        public bool Remove(string key)
        {
            return HttpContext.Current.Cache.Remove(key) != null ? true : false;
        }

        public void Clear()
        {
            IDictionaryEnumerator enumerator = HttpContext.Current.Cache.GetEnumerator();
            while (enumerator.MoveNext())
            {
                HttpContext.Current.Cache.Remove(enumerator.Key.ToString());
            }
        }

    }
}