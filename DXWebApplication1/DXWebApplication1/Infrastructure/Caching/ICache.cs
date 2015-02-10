using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXWebApplication1.Infrastructure.Caching
{
    public interface ICache
    {
        object Get(string key);

        void Put(string key, object value);

        void Put(string key, object value, double expiration);

        bool Remove(string key);

        void Clear();
    }
}
