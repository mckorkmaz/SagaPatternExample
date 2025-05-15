using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SagaPattern.Shared
{
    public class CreateOrder
    {
        public Guid OrderId { get; set; } = Guid.NewGuid();
        public Guid ProductId { get; set; } = Guid.NewGuid();
        public string CardNumber { get; set; } = "11";
    }
}
