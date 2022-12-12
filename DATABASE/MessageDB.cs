using BASE;
using Dapper;
using MySqlConnector;
namespace DATABASE;
public class MessageDB : IMessageHandeler
{
    public void CreateMessage(Message message)
    {
        int id = 0;
        using (MySqlConnection connection = new MySqlConnection($"Server=localhost;Database=2gether;Uid=root;Pwd=;"))
        {
            string? query = "INSERT INTO message (content, sender_id, receiver_id) VALUES (@Content,@SenderId,@ReceiverId);";
            id = connection.ExecuteScalar<int>(query, param: message);
        }
    }

    // public List<User> GetMyMessages(int messageId, int otherUserId, int myId)
    // {
    //     List<User> messages = new();

    //     using (MySqlConnection connection = new MySqlConnection($"Server=localhost;Database=2gether;Uid=root;Pwd=;"))
    //     {
    //         string query = "SELECT m.id,m.content,u1.first_name AS 'sender',u2.first_name AS 'receiver' " +
    //         "FROM message m INNER JOIN user_account u1 ON u1.id = m.sender_id INNER JOIN user_account u2 " +
    //         " ON u2.id = m.receiver_id WHERE (u2.id = @otheruserId AND u1.id = @myid) OR (u2.id = @myid AND u1.id = @otheruserid); ";
    //         messages = connection.Query<User>(query, new { @messageId = messageId, @otheruserId = otherUserId, @myid = myId }).ToList();
    //     }
    //     return messages;
    // }

    public List<Message> GetMyMessages(User user)
    {
        List<Message> messages = new();

        using (MySqlConnection connection = new MySqlConnection($"Server=localhost;Database=2gether;Uid=root;Pwd=;"))
        {
            string query = "SELECT m.id,m.content,u1.first_name AS 'sender',u2.first_name AS 'receiver' " +
            "FROM message m INNER JOIN user_account u1 ON u1.id = m.sender_id INNER JOIN user_account u2 " +
            " ON u2.id = m.receiver_id";
            messages = connection.Query<Message>(query, param: user).ToList();
        }
        return messages;
    }

    // List<Message> IMessageHandeler.GetMyMessages(User user)
    // {
    //     throw new NotImplementedException();
    // }
}