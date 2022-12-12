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
        MessageOperator messageOperator = new(userService, loginService, matchService, messageService);
        User user = new();
        int answer = 0;
        bool loggedIn = false;
        while (loggedIn)
            Console.WriteLine("2gether");
        answer = ConsoleInput.GetInt($"[1] Skapa konto [2] Logga in");

        switch (answer)
        {
            case 1:
                user = new();
                user = userOperator.CreateUser();
                break;
            case 2:
                int id = userOperator.LoginUser();
                // hämta ut hela usern på detta id
                user = new();
                user = userOperator.GetUser(id);
                if (user == null) break;
                loggedIn = true;
                Console.WriteLine(user.Name);

                while (loggedIn)
                {
                    int answer1 = ConsoleInput.GetInt($"Welcome {user.Name}\n  [1] Logga ut  [2] Your description [3] Make a match\n [4] My matches  [5] My YES-matches [6] My messages [7] Write message\n [8] Delete my account");
                    switch (answer1)
                    {
                        case 1:
                            Environment.Exit(0);
                            break;
                        case 2:
                            userOperator.UpdateUserDescription(user);
                            break;
                        case 3:
                            matchOperator.ChooseCriterias(user);
                            break;
                        case 4:
                            userOperator.ShowUsers(user);
                            break;
                        case 5:
                            userOperator.ShowUsers(user);
                            userOperator.SayYesOrNOToMatch(user);
                            break;
                        case 6:
                            messageOperator.ShowSenders(user);
                            int id2 = ConsoleInput.GetInt("Choose conversation: ");
                            messageOperator.ShowMessageConversation(user, id2);
                            messageOperator.SendMessage(id2, user);
                            break;
                        case 7:
                            Message message = new();
                            int senderId = 0;
                            int receiverId = 0;
                            messageOperator.SendMessage(receiverId, user);
                            break;
                        case 8:
                            userOperator.DeleteUser(user);
                            
                            break;
                    }
                }
                break;

        }

    }
}