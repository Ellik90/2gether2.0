using BASE;
using DATABASE;
namespace LOGIC;
public class LoginService : ILoginService
{
    IUserHandeler _userHandeler;

    public LoginService(IUserHandeler userHandeler)
    {
        _userHandeler = userHandeler;
    }


    public User UserLogIn(User user)
    {
        if (_userHandeler.UserEmailExists(user.Email) == true)
        {
            Console.WriteLine("Valid email");
        }
        else
        {
            Console.WriteLine("Unvalid email");
        }
        return user;
    }

    public int UserLoginIsValid(User user)
    {
        return _userHandeler.UserLogInExists(user);
    }
}