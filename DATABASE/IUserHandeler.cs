namespace DATABASE;
public interface IUserHandeler
{
    public int CreateUser(User user);
    public int DeleteUser(User user);  
    public bool UserEmailExists(string email);
    public List<User> GetUser();
}