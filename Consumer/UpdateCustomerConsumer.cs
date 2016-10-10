using Contract;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumer
{
    public class UpdateCustomerConsumer :
        IConsumer<UpdateCustomerAddress>
    {
        public async Task Consume(ConsumeContext<UpdateCustomerAddress> context)
        {
            await Console.Out.WriteLineAsync($"Updating customer: {context.Message.CustomerId}");

            // update the customer address
        }
    }
}
