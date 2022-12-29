using LOGIC;
using DATABASE;
using BASE;
public class UserOperator
{
    IUserService _userService;
    ILoginService _loginService;
    IMatchService _matchService;

    public UserOperator(IUserService userService, ILoginService loginService, IMatchService matchService)
    {
        _userService = userService;
        _loginService = loginService;
        _matchService = matchService;
    }
    public UserOperator() { }

    public void DeleteUser(User user)
    {
        try
        {
            _userService.DeleteUser(user);
            Console.WriteLine("Account deleted!");
            Environment.Exit(0);
        }
        catch (MySqlConnector.MySqlException)
        {
            Console.WriteLine("The site is under construction. Try again later.");
        }
    }
    
    public User CreateUser()
    {
        //LandScape landScape = new();
        User user = new();
        bool exists = true;

        user.Name = ConsoleInput.GetString($"Namn:  ");
        user.LastName = ConsoleInput.GetString($"Efternamn: ");
        user.Age = ConsoleInput.GetInt($"Age: ");
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
        if (user.Id < 1)
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
        string description = ConsoleInput.GetString("About me: ");
        _userService.UpdateUserDescription(user, description);
    }

    public void UpdateUserEmail(User user)
    {
        string email = ConsoleInput.GetString("New email: ");
        _userService.UpdateUserEmail(user, email);
    }

    public void UpdateUserPassword(User user)
    {
        string password = ConsoleInput.GetString("New Password: ");
        _userService.UpdateUserPassword(user, password);
    }

    public User GetUser(int id)
    {
        User user = _userService.GetUser(id);
        _matchService.GetMatches(user); //Har den här tillsvidare1
        if (user == null)
        {
            Console.WriteLine("Cant find user");
            return null;
        }
        else
        {
            return user;
        }
    }

    public void ShowMyMatches(User user)
    {
        List<User> list = new();
        list = _matchService.GetMatches(user);
        if (list == null) Console.WriteLine("No matches");
        else
        {
            foreach (User item in list)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}





