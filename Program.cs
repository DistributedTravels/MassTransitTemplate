using MassTransit;
using MassTransitTemplate.Consumers;
using MassTransitTemplate.Models;
var builder = WebApplication.CreateBuilder(args);


// configuration for mass transit
builder.Services.AddMassTransit(cfg =>
{
    // adding consumers
    cfg.AddConsumer<TemplateReceivedEventConsumer>();

    // telling masstransit to use rabbitmq
    cfg.UsingRabbitMq((context, rabbitCfg) =>
    {
        // rabbitmq config
        rabbitCfg.Host("rabbitmq", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });
        // automatic endpoint configuration (and I think the reason why naming convention is important
        rabbitCfg.ConfigureEndpoints(context);
    });
});

var app = builder.Build();
// bus for publishing a message, to check if everything works
// THIS SHOULD NOT EXIST IN FINAL PROJECT

var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
{
    cfg.Host("rabbitmq", "/", h =>
    {
        h.Username("guest");
        h.Password("guest");
    });
});
busControl.Start();
await busControl.Publish<TemplateReceivedEvent>(new TemplateReceivedEvent());
busControl.Stop();
app.Run();
