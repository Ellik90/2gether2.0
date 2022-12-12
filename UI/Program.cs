using BASE;
using LOGIC;
using DATABASE;
internal class Program
{
    private static void Main(string[] args)

    {

        
        MatchService matchService = new(new MatchDB());
        LoginService loginService = new(new UserDB());
        UserService userService = new(new UserDB());
        MessageService messageService = new(new MessageDB());
        MatchOperator matchOperator = new(userService, loginService, matchService);
        UserOperator userOperator = new(userService, loginService, matchService);
        MessageOperator messageOperator = new(userService,loginService,matchService,messageService);
        User user = new();
        int answer = 0;

        Console.WriteLine("2gether");
        answer = ConsoleInput.GetInt($"[1] Logga in [2] Skapa konto [3] Kontakta kundtjänst ");

        switch (answer)
        {
            case 1:
                int id = userOperator.LoginUser();
                // hämta ut hela usern på detta id
                user = new();
                user = userOperator.GetUser(id);
                if (user == null) break;
                Console.WriteLine(user.Name);



                int answer1 = ConsoleInput.GetInt($"Welcome {user.Name}\n  [1] Update information [2] Your description [3] Make a match\n [4] My matches  [5] My YES-matches [6] My messages");
                if (answer1 == 2)
                {
                    userOperator.UpdateUserDescription(user);
                }
                else if (answer1 == 3)
                {
                    matchOperator.ChooseCriterias(user);
                }
                else if (answer1 == 4)
                {
                    userOperator.ShowUsers(user);
                }
                else if (answer1 == 5)
                {
                    userOperator.ShowUsers(user);
                    userOperator.SayYesOrNOToMatch(user); // kolla över denna knasiga
                }
                else if (answer1 == 6)
                {
                    // int messageId = 0;
                    // int participantId = 0;
                    messageOperator.ShowMessageConversation(user);
                }
                break;
            case 2:
                user = new();
                user = userOperator.CreateUser();
                ConsoleInput.GetInt($"Welcome {user.Name}\n  [1] Update information [2] Your description [3] Make a match\n [4] My matches");
                break;
            case 3:
                break;

        }

    }
}