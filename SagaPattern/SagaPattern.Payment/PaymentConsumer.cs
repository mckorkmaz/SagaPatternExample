using MassTransit;
using SagaPattern.Shared;

namespace SagaPattern.Payment
{
    public sealed class PaymentConsumer(IPublishEndpoint publishEndpoint) : IConsumer<CreateOrder>
    {
        public async Task Consume(ConsumeContext<CreateOrder> context)
        {
            //payment success or failed operation
            var result = new PaymentResult
            {
                OrderId = context.Message.OrderId,
                ProductId = context.Message.ProductId,
                IsDone = true
            };
            await publishEndpoint.Publish(result);

        }
    }
}
