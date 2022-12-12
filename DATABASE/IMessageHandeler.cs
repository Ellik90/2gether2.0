using BASE;
namespace DATABASE;
public interface IMessageHandeler
{
    //public void CreateMessage(Message message);
    public List<Message> GetMyMessages( User user );
}