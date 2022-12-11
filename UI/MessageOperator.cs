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

        public void SendMessage(int idToUser, User user, string reciever)
    {
        
        string content = ConsoleInput.GetString("Content: ");
        Message newMessage = new( content, user.Id, idToUser);
        if (reciever == "user")
        {
            try
            {
                _messageService.MakeMessage(newMessage);
                Console.WriteLine("Message sent!");
            }
            catch(Exception)
            {
                Console.WriteLine("Something went wrong.");
            }
        }

     public Message GetMessages(int id)
    {
        Message message = _messageService.GetMessages(id);
         //Har den här tillsvidare1
        if (message == null)
        {
            Console.WriteLine("You dont have any messages");
            return null;
        }
        else
        {
            return message;
        }

    }
    
}