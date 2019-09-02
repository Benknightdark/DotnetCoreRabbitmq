using System;
using System.Text;
using RabbitMQ.Client;

namespace Producer {
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
                var body = Encoding.UTF8.GetBytes ("aaaaa");
                chanel.BasicPublish ("", "basic", null, body);
            }
            Console.WriteLine ("科");
            Console.ReadLine ();
        }
    }
}