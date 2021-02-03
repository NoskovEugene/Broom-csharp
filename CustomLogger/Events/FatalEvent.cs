using System;

namespace CustomLogger.Events
{
    public class FatalEvent : IExceptionableEvent
    {
        public string Text { get; set; }

        public Exception Exception { get; set; }
    }
}