using BASE;
namespace DATABASE;
public interface IUserHandeler
{
    public int CreateUser(User user);
    public int DeleteUser(User user);  
    public bool UserEmailExists(string email);
    public bool UserPersonalNumberExists(string personalNumber);
    public User GetUser(int id);
    public int Update(User user);
    public int UserLogInExists(User user);
}