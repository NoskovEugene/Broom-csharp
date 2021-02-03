using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CustomLogger.Writers;

namespace CustomLogger
{
    public class LoggerBuilder
    {
        IList<IWriter> writers { get; }

        string from { get; set; }

        public LoggerBuilder()
        {
            writers = new List<IWriter>();
        }

        public LoggerBuilder From(string fromPath)
        {
            from = fromPath;
            return this;
        }

        public LoggerBuilder UseConsole()
        {
            writers.Add(new ConsoleWriter());
            return this;
        }

        public LoggerBuilder UseFile(string path)
        {
            writers.Add(new FileWriter(path));
            return this;
        }

        public ILogger Build()
        {
            return new Logger(writers, from);
        }

        public void Reset()
        {
            writers.Clear();
        }
    }
}