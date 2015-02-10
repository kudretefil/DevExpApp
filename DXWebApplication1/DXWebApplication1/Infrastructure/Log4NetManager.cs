using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DXWebApplication1.Infrastructure
{
    public class Log4NetManager
    {
        public static ILog GetLogger(string loggerName = "EntityLogger")
        {
            ILog _logger = LogManager.Exists(loggerName);
            if (_logger == null)
                _logger = LogManager.GetLogger(loggerName);
            return _logger;
        }
    }
}