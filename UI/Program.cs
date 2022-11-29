using BASE;
using LOGIC;
using DATABASE;
internal class Program
{
    private static void Main(string[] args)

    {
        UserService userService = new(new UserDB());
        UserOperator userOperator = new(userService);
        User user = new();
        int answer = 0;

        Console.WriteLine("2gether");
        answer = ConsoleInput.GetInt($"[1] Logga in [2] Skapa konto [3] Kontakta kundtjänst ");

        switch (answer)
        {
            case 1:

                break;
            case 2:
           user = userOperator.CreateUser(user);
                break;
            case 3:
                break;
        }

    }
}