using Contract;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            var bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                cfg.Host(new Uri("rabbitmq://localhost"), h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });
                
            });

            bus.Start();

            //bus.Publish<UpdateCustomerAddress>(new
            //{
            //}).Wait();

            bus.GetSendEndpoint(new Uri("rabbitmq://localhost/customer_update_queue")).Result.Send(new UpdateCustomer
            {
                
            }).Wait();

            //bus.Send(new UpdateCustomer
            //{
                
            //}).Wait();

            Console.ReadLine();
        }
    }
}
