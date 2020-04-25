using SI.Common.Abstractions;
using System;
using Serilog;

namespace SI.Infrastructure.Logging {
    public class SerilogClient : SI.Common.Abstractions.ILogger {
         public void Error(string message, Exception ex) {
              Log.Error(ex, message);
         }
    }
}