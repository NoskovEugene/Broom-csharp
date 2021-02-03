using System;

namespace CustomLogger.Events
{
    public interface IExceptionableEvent : ITextableEvent
    {
        public  Exception Exception { get; set; }
    }
}