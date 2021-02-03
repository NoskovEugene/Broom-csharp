using CustomLogger.Events;

namespace CustomLogger.Writers
{
    public interface IWriter
    {
        void ExecuteEvent(Event @event);
    }
}