using System;
using System.Collections;
using System.Collections.Generic;
using CustomLogger.Events;
using CustomLogger.Writers;

namespace CustomLogger
{
    public class Logger : ILogger
    {
        IList<IWriter> Writers { get; }

        string From { get; }

        public Logger(IList<IWriter> writers, string from)
        {
            Writers = writers;
            From = from;
        }

        public void Trace(string message)
        {
            PushEvent(Prepare(EventTypeEnum.Trace, new TraceEvent()
                                                   {
                                                       Text = message
                                                   }));
        }

        public void Info(string message)
        {
            PushEvent(Prepare(EventTypeEnum.Info, new InfoEvent()
                                                  {
                                                      Text = message
                                                  }));
        }

        public void Warn(string message)
        {
            PushEvent(Prepare( EventTypeEnum.Warn, new WarnEvent()
                                                   {
                                                       Text =  message
                                                   }));
        }

        public void Error(string message)
        {
            PushEvent(Prepare(EventTypeEnum.Error, new ErrorEvent()
                                                   {
                                                       Text = message
                                                   }));
        }

        public void Fatal(string message)
        {
            PushEvent(Prepare(EventTypeEnum.Fatal, new FatalEvent()
                                                   {
                                                       Text = message
                                                   }));
        }

        public void Error(Exception exception)
        {
            PushEvent(Prepare(EventTypeEnum.Error, new ErrorEvent()
                                                   {
                                                       Text = exception.Message
                                                   }));
        }

        public void Fatal(Exception exception)
        {
            PushEvent(Prepare(EventTypeEnum.Fatal, new FatalEvent()
                                                   {
                                                       Text = exception.Message
                                                   }));
        }


        Event Prepare(EventTypeEnum eventType, ITextableEvent payload)
        {
            return new Event()
                   {
                       EventType = eventType,
                       From = From,
                       Payload = payload
                   };
        }

        void PushEvent(Event @event)
        {
            foreach (var writer in Writers)
            {
                writer.ExecuteEvent(@event);
            }
        }
    }
}