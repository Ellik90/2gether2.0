
using BASE;
using DATABASE;
namespace LOGIC;

public class UserService : IUserService
{
    
    IUserHandeler _userHandeler;
    public UserService(IUserHandeler userHandeler)
    {
        _userHandeler = userHandeler;
    }
    public UserService() { }

   

    public bool CreateUser(User user)
    {
        int rows = 0;
        rows = _userHandeler.CreateUser(user);
        if (rows > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public User GetUser(int id)
    {
        User user = _userHandeler.GetUser(id);
        if (user != null)
        {
            return user;
        }
        else
        {
            return null;
        }
        
    }
    public bool CheckUserEmailExists(string email)
    {
        bool rows = false;

        if (_userHandeler.UserEmailExists(email) == true)
        {
            rows = true;
        }
        return rows;
    }
    public bool CheckUserPersonalNumberExists(string personalNumber)
    {
        bool rows = false;

        if(_userHandeler.UserPersonalNumberExists(personalNumber) == true)
        {
            rows = true;
        }
        return rows;
    }
    public bool UpdateUserDescription(User user, string description)
    {

        bool rows = false;
        if(_userHandeler.UpdateUserDescription(user, description) < 1)
        {
            rows = true;
        }
        return rows;
    }
    
}