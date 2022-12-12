using BASE;
using DATABASE;
namespace LOGIC;
public interface IMessageService
{
    //public Message GetMessages(int id);
    //public List<Message> ShowOneMessageConversation(int messageId, int participantId, int myId);
    public List<Message> ShowOneMessageConversation(User user);

}