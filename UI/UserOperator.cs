using LOGIC;
using DATABASE;
using BASE;
public class UserOperator
{
    IUserService _userService;

    public UserOperator(IUserService userService)
    {
        _userService = userService;
    }
    public UserOperator() { }

    public User CreateUser(User user)
    {
        bool exists = true;

        // user.Name = ConsoleInput.GetString($"Namn:  ");
        // user.LastName = ConsoleInput.GetString($"Efternamn: ");
        user.Age = ConsoleInput.GetString($"Ålder: ");
        
        

         do
        {
            user.PersonalNumber = ConsoleInput.GetString($"Person nummer: ");
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
        // user.Gender = ConsoleInput.GetString($"Man kvinna hen ");
        _userService.CreateUser(user);
        return user;
    }

    public void LoginUser()
    {

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


