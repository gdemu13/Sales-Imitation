using System;

namespace SI.Common.Abstractions {
    public interface ILogger {
        void Error(string message, Exception ex);
        void Info(string message);
        void Info(object message);
    }
}