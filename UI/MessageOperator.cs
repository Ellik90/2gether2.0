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

    // public void ShowSenders(User user)
    // {
    //     List<User> users = _messageService.GetMySenders(user.Id);
    //     foreach (User item in users)
    //     {
    //         Console.WriteLine($" {item.Name}   [{item.Id}]");
    //     }
    // }

    public void ShowMessageConversation(User user, int id2)
    {
        try
        {
            List<Message> messages = _messageService.GetOneMessageConversation(user, id2);
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

    public void SendMessage(int receiverId, User user)
    {
        string content = ConsoleInput.GetString("Content: ");
        Message newMessage = new(content);
        newMessage.SenderId = user.Id;
        newMessage.ReceiverId = receiverId;
        try
        {
            _messageService.MakeMessage(newMessage);
            Console.WriteLine("Message sent!");
        }
        catch (Exception e)
        {
            Console.WriteLine("Couldnt send message, make sure you have the right conversation id!");
        }
    }
}



