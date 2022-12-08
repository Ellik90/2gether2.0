using BASE;
using DATABASE;
namespace LOGIC;
public interface IMatchService
{
    public List<User> GetMatches(User user);
    public void SetTheMatches(User user);
}