using BASE;
using Dapper;
using MySqlConnector;
namespace DATABASE;
public class MessageDB
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

    public List<User> GetMyMessages(User user)
    {
        List<User> messages = new();

        using (MySqlConnection connection = new MySqlConnection($"Server=localhost;Database=2gether;Uid=root;Pwd=;"))
        {
            string query = "SELECT m.id,m.content,u1.first_name AS 'sender',u2.first_name AS 'receiver' " +
            "FROM message m INNER JOIN user_account u1 ON u1.id = m.sender_id INNER JOIN user_account u2 " +
            " ON u2.id = m.receiver_id";
            messages = connection.Query<User>(query, param: user).ToList();
        }
        return messages;
    }

}