using DXWebApplication1.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DXWebApplication1.Infrastructure.Caching
{
    public class BildirimCache : BaseCache<BILDIRIM>
    {
        private static BildirimCache _instance;

        public static BildirimCache Current
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockObj)
                    {
                        if (_instance == null)
                            _instance = new BildirimCache();
                    }
                }
                return _instance;
            }
        }

        protected BildirimCache() { }



        protected override string GetCacheKey()
        {
            return SystemConst.BildirimCacheKey;
        }


        public BILDIRIM GetEtiketlemeById(int Id)
        {
            return GetCachedList().Where(e => e.BILDIRIM_ID == Id).FirstOrDefault();
        }
    }
}