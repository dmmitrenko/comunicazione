using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunicazione.Core.Repositories
{
    public interface ILoggerManager
    {
        void LogInfo(string message);
        void LogWarm(string message);
        void LogDebug(string message);
        void LogError(string message);

    }
}
