using System;
using CustomLogger.Events;
using System.IO;

namespace CustomLogger.Writers
{
    public class FileWriter : IWriter
    {
        protected string Path { get; }

        public FileWriter(string path)
        {
            Path = path;
        }

        public void ExecuteEvent(Event @event)
        {
            try
            {
                File.WriteAllText(Path, @event.Payload.Text);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}