using LOGIC;
using DATABASE;
using BASE;

public class MessageOperator
{
    IUserService _userService;
    ILoginService _loginService;
    IMatchService _matchService;
    IMessageService _messageService;

    public MessageOperator(IUserService userService, ILoginService loginService, IMatchService matchService, IMessageService messageService)
    {
        _userService = userService;
        _loginService = loginService;
        _matchService = matchService;
        _messageService = messageService;
    }

    public void ShowMessageConversation( User user)
    {
        try
        {
            List<Message> messages = _messageService.ShowOneMessageConversation(user);
            Console.WriteLine();
            foreach (Message item in messages)
            {
                Console.WriteLine(item.MessageTostring());
            }
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("No conversation found.");
        }
    }

    // public Message GetMessages(int id)
    // {
    //     Message message = _messageService.GetMessages(id);
    //     //Har den här tillsvidare1
    //     if (message == null)
    //     {
    //         Console.WriteLine("You dont have any messages");
    //         return null;
    //     }
    //     else
    //     {
    //         return message;
    //     }

    // }

}