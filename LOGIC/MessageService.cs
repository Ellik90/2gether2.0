using BASE;
using DATABASE;
namespace LOGIC;

public class MessageService : IMessageService
{
    IMessageHandeler _messageHandeler;
    List<Message> allMessages = new();
    Message message = new();
    public MessageService(IMessageHandeler messageHandeler)
    {
        _messageHandeler = messageHandeler;
    }
    public MessageService() { }

    // public List<User> GetMySenders(int id)
    // {
    //     List<User> users = _messageHandeler.GetMySenders(id);
    //     return users;
    // }
    
    public void MakeMessage(Message message)
    {
        _messageHandeler.CreateMessage(message);
    }

    public List<Message> GetOneMessageConversation(User user, int id2)
    {
        List<Message> messages = _messageHandeler.GetMyMessages(user, id2);
        return messages;
    }


}