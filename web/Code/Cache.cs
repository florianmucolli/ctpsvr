using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Citiport.Cache;
using System.Web.Caching;
using System.Collections;

namespace CtpSvr.Code
{
    public class AppCache : ICacheManager
    {
        HttpContext _context = null;

        internal AppCache()
        {
            _context = HttpContext.Current;
        }

        public void put(object o, string key)
        {
            if (_context != null)
                _context.Cache.Insert(key,o);
        }

        public void put(object o, string key, TimeSpan duration)
        {
            if (_context != null)
                _context.Cache.Insert(key, o, null, Cache.NoAbsoluteExpiration, duration);
        }

        public object get(string key)
        {
            if (_context != null)
            {
                return _context.Cache.Get(key);
            }
            return null;
        }

        public void clean()
        {
            if (_context != null)
            {
                IDictionaryEnumerator ie = _context.Cache.GetEnumerator();
                while (ie.MoveNext())
                {
                    _context.Cache.Remove(ie.Key.ToString());
                }
            }
        }
    }

    public class CacheFactory
    {
        public static ICacheManager GetCache()
        {
            return new AppCache();
        }
    }

}