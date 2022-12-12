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


    //  public bool MakeMessage(Message message)
    // {
    //     int rows = _messageHandeler.CreateMessage(message);
    //     if(rows > 0)
    //     {
    //         return true;
    //     }
    //     else
    //     {
    //         return false;
    //     }
    // }

    

     public List<Message> ShowOneMessageConversation(User user)
    {
        
        List<Message> messages = _messageHandeler.GetMyMessages( user);
        return messages;
    }

    
}