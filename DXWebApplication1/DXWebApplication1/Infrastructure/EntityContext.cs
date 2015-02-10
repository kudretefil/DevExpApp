using DXWebApplication1.Infrastructure.Caching;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DXWebApplication1.Infrastructure
{
        public class EntityContext
        {
            private static EntityContext _instance;
            private static object lockObj = new object();
            private object cacheLock = new object();

            public static EntityContext Current
            {
                get
                {
                    if (_instance == null)
                    {
                        lock (lockObj)
                        {
                            if (_instance == null)
                                _instance = new EntityContext();
                        }
                    }

                    return _instance;
                }
            }

            protected EntityContext() { }



            private static ICache _appCache;

            public ICache AppCache
            {
                get
                {
                    lock (cacheLock)
                    {
                        if (_appCache == null)
                        {
                            _appCache = new LocalCacheProvider();
                        }

                        return _appCache;
                    }
                }
            }


            private static readonly ILog _logger = Log4NetManager.GetLogger();

            public static ILog Logger
            {
                get { return _logger; }
            }


         
        }
    
}