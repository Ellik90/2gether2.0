using BASE;
namespace DATABASE;
public interface IUserHandeler
{
    public int CreateUser(User user);
    public int DeleteUser(User user);  
    public bool UserEmailExists(string email);
     public int UpdateUserEmail(User user, string email);
     public int UpdateUserPassword(User user, string password);
    public bool UserPersonalNumberExists(string personalNumber);
    public User GetUser(int id);
    public int UpdateUserDescription(User user, string description);
    public int UserLogInExists(User user);
}