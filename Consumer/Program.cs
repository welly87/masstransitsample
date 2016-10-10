using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host(new Uri("rabbitmq://localhost/"), h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                cfg.ReceiveEndpoint(host, e =>
                {
                    e.Consumer<UpdateCustomerConsumer>();
                });

                cfg.ReceiveEndpoint(host, "customer_update_queue", e =>
                {
                    e.Consumer<UpdateCustomerConsumer2>();
                });

                cfg.ReceiveEndpoint(host, e =>
                {
                    e.Consumer<UpdateCustomerConsumer2>();
                });

            });

            busControl.Start();

            Console.ReadLine();
        }
    }
}
