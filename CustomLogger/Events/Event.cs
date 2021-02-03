namespace CustomLogger.Events
{
    public class Event
    {
        public string From { get; set; }

        public EventTypeEnum EventType { get; set; }
        
        public ITextableEvent Payload { get; set; }
    }
}