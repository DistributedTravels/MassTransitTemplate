namespace MassTransitTemplate.Models
{
    // Class used as received message
    // Not sure if naming convention is important here, so go wild I guess (please don't)
    public class TemplateReceivedEvent
    {
        public Guid Id { get; set; } // ID of this message (might be unnecessary, as MassTransit adds adds its own ID, but useful I guess)
        public Guid GreatDesignId { get; set; } // Whatever additional IDs needed by processes (could be none)
        public string InformationA { get; set; } // Additional information
        public string InformationB { get; set; } // Additional information

        public TemplateReceivedEvent()
        {
            Id = Guid.NewGuid();
            GreatDesignId = Guid.NewGuid();
            InformationA = "whatever";
            InformationB = "also whatever";
        }
    }
}
