


using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;


namespace RabbitMqDemo
{
    public static class Producer
    {

        public async static Task<string> Main()
        {
            ConnectionFactory factory = new ConnectionFactory();
            factory.UserName = "guest";
            factory.Password = "guest";

            factory.VirtualHost = "/";
            factory.HostName = "localhost";

            await using IConnection conn = await factory.CreateConnectionAsync();
            await using var channel = await conn.CreateChannelAsync();

            await channel.ExchangeDeclareAsync("Nirlaz-Exchange", ExchangeType.Direct);
            await channel.QueueDeclareAsync("Nirlaz-Queue", false, false, false);
            await channel.QueueBindAsync("Nirlaz-Queue", "Nirlaz-Exchange", "route_key");
         
            for(int i=0; i <= 100; i++) {
                var message = $"{i}";
                var json = JsonConvert.SerializeObject(message);
                var body = Encoding.UTF8.GetBytes(json);
                Console.WriteLine(message);


                await channel.BasicPublishAsync(exchange: "Nirlaz-Exchange", routingKey: "route_key", body: body);
            }
            
            return "ok";

        }


    }
}
