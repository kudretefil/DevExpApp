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

         
        }
    
}