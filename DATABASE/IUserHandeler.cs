using BASE;
namespace DATABASE;
public interface IUserHandeler
{
    public int CreateUser(User user);
    public int DeleteUser(User user);  
    public bool UserEmailExists(string email);
    public bool UserPersonalNumberExists(string personalNumber);
    public List<User> GetUser();
    public int UpdateUserDescription(string aboutMe);
    public int UserLogInExists(User user);
}