using BASE;
using DATABASE;
namespace LOGIC;
public interface IMessageService
{
   
    //public List<Message> ShowOneMessageConversation(int messageId, int participantId, int myId);
    public List<Message> GetOneMessageConversation(User user, int id2);
    public void MakeMessage(Message message);
    public List<User> GetMySenders(int id);

}