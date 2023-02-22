namespace BibliotekaAPI.Repositrory
{
    public interface IRabbitMqSender
    {
        public void SendMessage<T>(T message);
    }
}
