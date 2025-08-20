using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace RabbitMqDemo
{
    public static class Receiver
    {
        public async static Task Main()
        {
            ConnectionFactory factory = new ConnectionFactory();
            factory.UserName = "guest";
            factory.Password = "guest";
            factory.VirtualHost = "/";
            factory.HostName = "localhost";

            await using IConnection conn = await factory.CreateConnectionAsync();
            await using var channel = await conn.CreateChannelAsync();


            var consumer = new AsyncEventingBasicConsumer(channel);
            consumer.ReceivedAsync += async (model, args) =>
            {
                var body = args.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine($"[x] Received: {message}");
                await Task.Delay(9000);
            };

            await channel.BasicConsumeAsync("Nirlaz-Queue", true, consumer);

            Console.WriteLine("Listening for messages. Press [enter] to exit.");
            Console.ReadLine(); // Keeps the app running
        }
    }
    public static class Receiver1
    {
        public async static Task Main()
        {
            ConnectionFactory factory = new ConnectionFactory();
            factory.UserName = "guest";
            factory.Password = "guest";
            factory.VirtualHost = "/";
            factory.HostName = "localhost";

            await using IConnection conn = await factory.CreateConnectionAsync();
            await using var channel = await conn.CreateChannelAsync();


            var consumer = new AsyncEventingBasicConsumer(channel);
            consumer.ReceivedAsync += async (model, args) =>
            {
                var body = args.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine($"[x] Received1: {message}");
                await Task.Delay(8000);
            };

            await channel.BasicConsumeAsync("Nirlaz-Queue", true, consumer);

            Console.WriteLine("Listening for messages. Press [enter] to exit.");
            Console.ReadLine(); // Keeps the app running
        }
    }
}
