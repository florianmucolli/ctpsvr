using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Citiport.Cache
{
    public interface ICacheManager
    {
        void put(object o, string key);
        object get(string key);
        void clean();
    }
}
