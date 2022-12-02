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
}