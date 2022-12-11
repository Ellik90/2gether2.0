using BASE;
using DATABASE;
namespace LOGIC;
public interface IMessageService
{
    public Message GetMessages(int id);
}