namespace BASE;
public class Message
{
    int Id { get; set; }
    string Content { get; set; }
    int SenderId { get; set; }
    int ReceiverId { get; set; }
    DateTime Created { get; set; }
}