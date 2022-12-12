using BASE;
using DATABASE;
namespace LOGIC;
public interface IUserService
{
    
    public bool CreateUser(User user);
    public bool CheckUserEmailExists(string email);
    public bool CheckUserPersonalNumberExists(string personalNumber);
    public bool UpdateUserDescription(User user, string description);
    public User GetUser(int id);
    public bool DeleteUser(User user);
}