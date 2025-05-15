using MassTransit;
using SagaPattern.OrderService;
using SagaPattern.Shared;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<OrderConsumer>();
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("rabbitmq://localhost", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        cfg.ReceiveEndpoint("order-payment-result",e=>
        {
            e.ConfigureConsumer<OrderConsumer>(context);
        });
    });
});

var app = builder.Build();



app.MapDefaultEndpoints();

//IPublishEndpoint publishEndpoint model ne yazarsam onun isminde gönderir direkt
app.MapGet("/create-order", async (IPublishEndpoint publishEndpoint) =>
{
    //create order
    //send to queue for payment
    //operation completed and send to users with notification

    await publishEndpoint.Publish(new CreateOrder());
    return Results.Created();
});

app.Run();
