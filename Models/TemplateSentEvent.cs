namespace MassTransitTemplate.Models
{
    // Class used as message for sending
    // Not necessary, but added to show publishing
    // Fields similar to TemplateReceivedEvent
    public class TemplateSentEvent
    {
        public Guid Id { get; set; }
        public Guid GrandDesignId { get; set; }
        public string NewInformation { get; set; }

        public TemplateSentEvent()
        {
            Id = Guid.NewGuid();
            GrandDesignId = Guid.NewGuid();
            NewInformation = "the new NEW information";
        }
    }
}
