using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Consumer {
    class Program {
        static void Main (string[] args) {
            var factory = new ConnectionFactory ();

            factory.UserName = ("rabbitmq");
            factory.Password = ("rabbitmq");
            factory.HostName = ("localhost");
            factory.Port = (5672);
            using (var connection = factory.CreateConnection ())
            using (var chanel = connection.CreateModel ()) {
                chanel.QueueDeclare ("basic", false, false, false, null);
                var Consummer = new EventingBasicConsumer (chanel);
                Consummer.Received += (model, ea) => {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString (body);
                    Console.WriteLine (message);
                };
                string bb = chanel.BasicConsume ("basic", true, Consummer);
                Console.WriteLine (bb);

            }
            // Console.WriteLine ("科"); 
            Console.ReadLine ();
        }
    }
}