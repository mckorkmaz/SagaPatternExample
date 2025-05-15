using MassTransit;
using SagaPattern.Payment;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddMassTransit(x =>
{
    //consumer çalışması için ConfigureEndpoints yapılandırılması gerekiyor.
    x.AddConsumer<PaymentConsumer>();

    x.UsingRabbitMq((context, cfr) =>
    {
        cfr.Host("localhost", "/", h => { });
        //consumer dinleyebilmesi için kendi bir kuyruk oluşturuyor
        cfr.ReceiveEndpoint("payment-result",e=>
        {
            e.ConfigureConsumer<PaymentConsumer>(context);
        });
        
       
    });
});

var app = builder.Build();

app.MapDefaultEndpoints();

app.MapGet("/", () => "Hello World!");

app.Run();
