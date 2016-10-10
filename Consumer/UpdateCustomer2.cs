using Contract;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumer
{
    public class UpdateCustomerConsumer2 :
        IConsumer<UpdateCustomer>
    {
        public async Task Consume(ConsumeContext<UpdateCustomer> context)
        {
            await Console.Out.WriteLineAsync($"Updating customer: {context.Message}");

            // update the customer address
        }
    }
}
