using BASE;
using Dapper;
using MySqlConnector;
namespace DATABASE;
public class MessageDB : IMessageHandeler
{
    public int CreateMessage(Message message)
    {
        int messageId = 0;
        using (MySqlConnection connection = new MySqlConnection($"Server=localhost;Database=2gether;Uid=root;Pwd=;"))
        {
            string? query = "INSERT INTO message (content, sender_id, receiver_id) VALUES (@Content,@SenderId,@ReceiverId);SELECT LAST_INSERT_ID()";
            messageId = connection.ExecuteScalar<int>(query, new { @Content = message.Content, @SenderId = message.SenderId, @ReceiverId = message.ReceiverId });
        }
        return messageId;
    }


    public List<Message> GetMyMessages(User user, int id2)
    {
        List<Message> messages = new();
        using (MySqlConnection connection = new MySqlConnection($"Server=localhost;Database=2gether;Uid=root;Pwd=;"))
        {
            string query = "SELECT m.id,m.content,u1.first_name AS 'sender' " +
                           "FROM message m INNER JOIN user_account u1 ON u1.id = m.sender_id INNER JOIN user_account u2 " +
                           "ON u2.id = m.receiver_id WHERE u1.id = @id AND u2.id = @id2 or u2.id = @id AND u1.id = @id2;";
            messages = connection.Query<Message>(query, new { @id2 = id2, @id = user.Id }).ToList();
        }
        return messages;
    }
}

    // public List<User> GetMySenders(int id)
    // {
    //     List<User> users = new();
    //     using (MySqlConnection connection = new MySqlConnection($"Server=localhost;Database=2gether;Uid=root;Pwd=;"))
    //     {
    //         string query = "SELECT ua.id AS 'Id' ,ua.first_name AS 'Name' " +
    //                        "FROM user_account ua INNER JOIN message m ON m.sender_id = ua.id " +
    //                        "WHERE m.receiver_id = @id ";
    //         users = connection.Query<User>(query, new { @id = id }).ToList();
    //     }
    //     return users;
    // }