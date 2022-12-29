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
                user = new();
                user = userOperator.GetUser(id);
                if (user == null) break;
                loggedIn = true;
                Console.WriteLine(user.Name);

                while (loggedIn)
                {
                    int answer1 = ConsoleInput.GetInt($"Inlogged as: {user.Name}\n [1] Log out [2] Your description [3] Make a match\n " +
                                                                               "[4] My matches [5] Delete matches [6] My messages " +
                                                                               "[7] Update email\n [8] Update password [9] Delete my account");
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
                            matchService.SetMatches(user); //sätt dit den.
                            break;
                        case 4:
                            userOperator.ShowMyMatches(user);
                            break;
                        case 5:
                            userOperator.ShowMyMatches(user);
                            // userOperator.DeleteMyMatch();
                            //delete match här
                            break;
                        case 6:
                            userOperator.ShowMyMatches(user);
                            messageOperator.ShowSenders(user);
                            int id2 = ConsoleInput.GetInt("Choose conversation: ");
                            messageOperator.ShowMessageConversation(user, id2);
                            messageOperator.SendMessage(id2, user);
                            break;
                        case 7:
                            userOperator.UpdateUserEmail(user);                                                   
                            break;
                        case 8:
                            userOperator.UpdateUserPassword(user);
                            break;
                        case 9:
                            userOperator.DeleteUser(user);
                            break;
                    }
                }
                break;

        }

    }


}