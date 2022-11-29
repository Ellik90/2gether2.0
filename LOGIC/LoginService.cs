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
        throw new NotImplementedException();
    }

    public int UserLoginIsValid(User user)
    {
        throw new NotImplementedException();
    }
}