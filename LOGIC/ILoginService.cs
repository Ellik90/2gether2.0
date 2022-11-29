using BASE;
using DATABASE;
namespace LOGIC;
public interface ILoginService
{
    public User UserLogIn(User user);
    public int UserLoginIsValid(User user);
}