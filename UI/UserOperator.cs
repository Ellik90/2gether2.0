using LOGIC;
using DATABASE;
using BASE;
public class UserOperator
{
    IUserService _userService;
    ILoginService _loginService;

    public UserOperator(IUserService userService, ILoginService loginService)
    {
        _userService = userService;
        _loginService = loginService;
    }
    public UserOperator() { }

    public User CreateUser()
    {
        LandScape landScape = new();
        User user = new();
        bool exists = true;

        user.Name = ConsoleInput.GetString($"Namn:  ");
        user.LastName = ConsoleInput.GetString($"Efternamn: ");
        user.Age = ConsoleInput.GetString($"Age: ");
        user.Gender = ConsoleInput.GetString($" Mr || Miss || Binary\n Your gender: ");
        ShowLandscapes();
        user.LandscapeId = ConsoleInput.GetInt("Ditt län: ");
        do
        {
            user.PersonalNumber = ConsoleInput.GetString($"Personal-number: ");
            if ((_userService.CheckUserPersonalNumberExists(user.PersonalNumber)))
            {
                Console.WriteLine("personal number alredy exists");
                exists = true;
            }
            else
            {
                exists = false;
            }
        } while (exists);
        do
        {
            user.Email = ConsoleInput.GetString($"Email: ");
            if ((_userService.CheckUserEmailExists(user.Email)))
            {
                Console.WriteLine("Email alredy exists");
                exists = true;
            }
            else
            {
                exists = false;
            }
        } while (exists);

        user.PassWord = ConsoleInput.GetString($"Password: ");
        _userService.CreateUser(user);
        return user;
    }

    public int LoginUser()
    {
        User user = new();
        user.Email = ConsoleInput.GetString($"Enter your email: ");
        user.PassWord = ConsoleInput.GetString($"Enter your password: ");
        user = _loginService.UserLogIn(user);
        user.Id = _loginService.UserLoginIsValid(user);
        if(user.Id  < 1)
        {
            Console.WriteLine("Fel");
        }
        return user.Id;
    }
    public void ShowLandscapes()
    {
        int index = 0;
        User.Landscapes allLandScapes = User.Landscapes.Undefined;
        foreach (string name in Enum.GetNames(typeof(User.Landscapes)))
        {
            Console.WriteLine($"[{index}] {name}");
            index++;
        }

    }

    public void UpdateUserDescription(User user)
    {
        user.AboutMe = ConsoleInput.GetString("About me: ");

    }
    public User GetUser(int id)
    {
        User user = _userService.GetUser(id);
        return user;
    }
}

//     do
//     {
//         user.SocialSecurityNumber = ConsoleInput.GetString("social security number: ");
//         if ((_validator.ValidateSocialSecurityNumber(user.SocialSecurityNumber) == false))
//         {
//             Console.WriteLine("social security number incorrect");
//             exists = true;
//         }
//         else
//         {
//             exists = false;
//         }
//     } while (exists);

//     user = _loginService.MakeNewLogIn(user);
//     _userService.MakeUser(user);
//     return user;
// }


