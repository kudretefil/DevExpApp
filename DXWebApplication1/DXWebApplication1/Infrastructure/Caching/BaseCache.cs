using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DXWebApplication1.Infrastructure.Caching
{
    public abstract class BaseCache<T> where T : class
    {
        protected static object lockObj = new object();

        public List<T> GetCachedList()
        {
            if (EntityContext.Current.AppCache.Get(GetCacheKey()) == null)
                return new List<T>();
            else return EntityContext.Current.AppCache.Get(GetCacheKey()) as List<T>;
        }

        public void AddCache(T entity, int duration)
        {
            List<T> cacheList = GetCachedList();
            cacheList.Add(entity);
            EntityContext.Current.AppCache.Put(GetCacheKey(), cacheList, duration);
        }

        public void AddCache(T entity)
        {
            List<T> cacheList = GetCachedList();
            cacheList.Add(entity);
            EntityContext.Current.AppCache.Put(GetCacheKey(), cacheList);
        }

        public void AddCacheList(List<T> entities)
        {
            List<T> cacheList = GetCachedList();
            cacheList.AddRange(entities);
            EntityContext.Current.AppCache.Put(GetCacheKey(), cacheList);
        }

        //public void AddCacheList(List<T> entities, double duration)
        //{
        //    List<T> cacheList = GetCachedList();
        //    cacheList.AddRange(entities);
        //    EntityContext.Current.AppCache.Put(GetCacheKey(), cacheList, duration);
        //}

        public void RemoveCache()
        {
            EntityContext.Current.AppCache.Remove(GetCacheKey());
        }

        protected abstract string GetCacheKey();

    }
}