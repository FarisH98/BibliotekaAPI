using Microsoft.AspNetCore.Connections;
using static BibliotekaAPI.Repositrory.RabbitMqSender;
using System.Text;

namespace BibliotekaAPI.Repositrory
{
    
        public class RabbitMqSender : IRabbitMqSender
        {
            public void SendMessage<T>(T message)
            {
                var factory = new ConnectionFactory() { HostName = "localhost" };
                var connection = factory.CreateConnection();
                var channel = connection.CreateModel();

                channel.QueueDeclare("FoodQueue", durable: true, exclusive: false, autoDelete: false);

                var json = JsonConvert.SerializeObject(message);
                var body = Encoding.UTF8.GetBytes(json);

                channel.BasicPublish(exchange: "",
                                    routingKey: "FoodQueue",
                                    basicProperties: null,
                                    body: body);

            }
        }
    }
}
