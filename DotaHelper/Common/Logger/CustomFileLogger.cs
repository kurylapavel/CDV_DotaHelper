using Common.Settings;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Logger
{
    public class CustomFileLogger : ICustomFileLogger
    {
        IOptions<LoggingSettings> _config;

        public CustomFileLogger(IOptions<LoggingSettings> config)
        {
            _config = config;
        }

        public void Log(Exception ex, string when)
        {
            var sb = new StringBuilder();

            sb.Append($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}\n");
            sb.Append($"Exception thrown when - {when}\n");
            sb.Append($"Exception message - {ex.Message}\n");
            sb.Append($"Exception Source - {ex.Source}\n");
            sb.Append($"Exception StackTrace - {ex.StackTrace}\n\n");

            File.AppendAllText(_config.Value.LogsFolderPath, sb.ToString());
        }
    }
}
