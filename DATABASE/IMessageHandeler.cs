using BASE;
namespace DATABASE;
public interface IMessageHandeler
{
     public int CreateMessage(Message message);
    public List<Message> GetMyMessages( User user, int id2 );
    // public List<User> GetMySenders(int id);
}