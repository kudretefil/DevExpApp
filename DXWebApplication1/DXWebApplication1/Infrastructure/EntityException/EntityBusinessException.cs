using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DXWebApplication1.Infrastructure.EntityException
{
    public class EntityBusinessException : Exception
    {
        public EntityBusinessException() : base() { 
        
        }

        public EntityBusinessException(string message)
            : base(message)
        {

        }
    }
}