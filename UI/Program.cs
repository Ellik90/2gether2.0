using BASE;
using LOGIC;
using DATABASE;
internal class Program
{
    private static void Main(string[] args)

    {
        LoginService loginService = new(new UserDB());
        UserService userService = new(new UserDB());
        UserOperator userOperator = new(userService, loginService);
        User user = new();
        int answer = 0;

        Console.WriteLine("2gether");
        answer = ConsoleInput.GetInt($"[1] Logga in [2] Skapa konto [3] Kontakta kundtjänst ");

        switch (answer)
        {
            case 1:
                int id = userOperator.LoginUser();
                // hämta ut hela usern på detta id
                User loggedInUser = new();
                loggedInUser = userOperator.GetUser(id);
                Console.WriteLine(loggedInUser.Name);
                break;
            case 2:
                user = userOperator.CreateUser();
                break;
            case 3:
                break;
        }

    }
}