using BASE;
namespace DATABASE;
public interface IMessageHandeler
{
    public void CreateMessage(Message message);
    public List<User> GetMyMessages(Message message);
}