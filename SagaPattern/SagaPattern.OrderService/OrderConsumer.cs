using MassTransit;
using SagaPattern.Shared;

namespace SagaPattern.OrderService
{
    public sealed class OrderConsumer : IConsumer<PaymentResult>
    {
        public Task Consume(ConsumeContext<PaymentResult> context)
        {
            //sipariş durumunu işlem başarılı yada başarısız yapabilir.
            //product kuyruğuna eğer işlem başarılı ise product kuyruğuna haber verip stoktan düşürülmesini sağlayabilir


            return Task.CompletedTask;
        }
    }
}
