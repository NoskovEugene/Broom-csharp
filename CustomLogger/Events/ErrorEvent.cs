using System;

namespace CustomLogger.Events
{
    public class ErrorEvent : IExceptionableEvent
    {
        public string Text { get; set; }

        public Exception Exception { get; set; }
    }
}