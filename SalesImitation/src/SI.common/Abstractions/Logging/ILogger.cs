using System;

namespace SI.Common.Abstractions {
    public interface ILogger {
        void Error(string message, Exception ex);
    }
}