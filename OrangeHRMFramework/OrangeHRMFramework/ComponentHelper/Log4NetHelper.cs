using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Layout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRMFramework.ComponentHelper
{
    public class Log4NetHelper
    {
        #region Field
        private static ILog _logger;
        private static RollingFileAppender _rollingFileAppender;
        private static string layout = "%date{dd-MM-yyyy-HH:mm:ss} [%class] [%level] [%method] - %message%newline";
        #endregion
        #region Property
        public static string Layout
        {
            set { layout = value; }
        }
        #endregion
        #region private
        private static PatternLayout GetPatternLayout()
        {
            var PatterLayout = new PatternLayout()
            {
                ConversionPattern = layout
            };
            PatterLayout.ActivateOptions();
            return PatterLayout;
        }

        private static RollingFileAppender GetRollingFileAppender()
        {
            var rollingAppender = new RollingFileAppender()
            {
                Name = "Rolling File Appender",
                AppendToFile = true,
                File = "RollingFile.log",
                Layout = GetPatternLayout(),
                Threshold = Level.All,
                MaximumFileSize = "1MB",
                MaxSizeRollBackups = 15
            };
            rollingAppender.ActivateOptions();
            return rollingAppender;

        }
        #endregion
        #region public
        public static ILog GetLooger(Type type)
        {
            if(_rollingFileAppender ==  null)
            {
                _rollingFileAppender = GetRollingFileAppender();
            }
            if(_logger !=null)
            {
                return _logger;
            }

            BasicConfigurator.Configure(_rollingFileAppender);
            _logger = LogManager.GetLogger(type);
            return _logger;
        }
        #endregion
    }

}

