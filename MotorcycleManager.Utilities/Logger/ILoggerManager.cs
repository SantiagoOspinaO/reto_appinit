using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorcycleManager.Utilities.Logger
{
    internal interface ILoggerManager
    {
        void LogInfo(string message);
        void LogWarning(string message);
        void LogDebug (string message);
        void LogError(string message);
    }
}
