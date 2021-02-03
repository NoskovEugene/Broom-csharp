using System;

namespace CustomLogger
{
    public interface ILogger
    {
        void Trace(string message);
        void Info(string message);
        void Warn(string message);
        void Error(string message);
        void Fatal(string message);
        void Error(Exception exception);
        void Fatal(Exception exception);
    }
}