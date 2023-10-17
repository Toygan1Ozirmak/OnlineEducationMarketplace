using NLog;
using OnlineEducationMarketplace.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationMarketplace.Services.Managers
{
    public class LoggerManager : ILoggerService
    {
        //nlog kullanıldı
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        public void LogDebug(string message)=> logger.Debug(message);

        public void LogError(string message)=> logger.Error(message);

        public void LogInfo(string message)=> logger.Info(message);

        public void LogWarning(string message)=> logger.Warn(message);
    }
}
