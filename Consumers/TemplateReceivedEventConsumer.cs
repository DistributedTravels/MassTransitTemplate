using MassTransit;
using MassTransitTemplate.Models;

namespace MassTransitTemplate.Consumers
{
    // Class for consuming TemplateReceivedEvent
    // note that naming convention is important, so name your consumers as [Event class name]Consumer
    // I've had some troubles with that...
    // at least I think so
    public class TemplateReceivedEventConsumer : IConsumer<TemplateReceivedEvent>
    {
        public async Task Consume(ConsumeContext<TemplateReceivedEvent> context)
        {
            // Do whatever when message is received
            // For example get info from message:
            Console.WriteLine($"Received message with this informationA: {context.Message.InformationA} and this informationB: {context.Message.InformationB}");
            // and publish something else:
            await context.Publish<TemplateSentEvent>(new TemplateSentEvent { NewInformation = "hello world"});
        }
    }
}
