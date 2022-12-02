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

    public bool UpdateUserDescription(string aboutMe)
    {
        bool rows = false;
        if(_userHandeler.UpdateUserDescription(aboutMe) < 1)
        {
            rows = true;
        }
        return rows;
    }
    
}