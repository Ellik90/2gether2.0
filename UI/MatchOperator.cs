using LOGIC;
using DATABASE;
using BASE;
public class MatchOperator
{
    IUserService _userService;
    ILoginService _loginService;
    IMatchService _matchService;

    public MatchOperator(IUserService userService, ILoginService loginService, IMatchService matchService)
    {
        _userService = userService;
        _loginService = loginService;
        _matchService = matchService;
    }
    public MatchOperator() { }

    public void MakeAMatch1(User user)
    {
        int age = ConsoleInput.GetInt("Vilket åldersspann är du intresserad av? ");
        ShowAgeSpan();
    }
}