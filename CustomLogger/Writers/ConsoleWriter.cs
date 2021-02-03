using System;
using System.Collections.Generic;
using CustomLogger.Events;

namespace CustomLogger.Writers
{
    public class ConsoleWriter : IWriter
    {
        public Dictionary<EventTypeEnum, ConsoleColor> Palette = new Dictionary<EventTypeEnum, ConsoleColor>()
                                                                 {
                                                                     {
                                                                         EventTypeEnum.Trace, ConsoleColor.Gray
                                                                     },
                                                                     {
                                                                         EventTypeEnum.Info, ConsoleColor.Green
                                                                     },
                                                                     {
                                                                         EventTypeEnum.Warn, ConsoleColor.Yellow
                                                                     },
                                                                     {
                                                                         EventTypeEnum.Error, ConsoleColor.Red
                                                                     },
                                                                     {
                                                                         EventTypeEnum.Fatal, ConsoleColor.DarkRed
                                                                     }
                                                                 };

        public void ExecuteEvent(Event @event)
        {
            var color = Palette[@event.EventType];
            var glass = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(@event.Payload.Text);
            Console.ForegroundColor = glass;
        }
    }
}