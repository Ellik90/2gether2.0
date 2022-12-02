using LOGIC;
using BASE;
using DATABASE;

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
        return user;
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
    public bool Update(User user)
    {

        bool rows = false;
        if(_userHandeler.Update(user) < 1)
        {
            rows = true;
        }
        return rows;
    }
    
}