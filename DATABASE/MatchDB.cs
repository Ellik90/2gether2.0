using Dapper;
using MySqlConnector;
using BASE;
using System.Collections.Generic;
namespace DATABASE;
public class MatchDB : IMatchHandeler
{
    public int LandscapeMatch(User user)
    {
        int rows = 0;
        using (MySqlConnection connection = new MySqlConnection($"Server=localhost;Database=2gether;Uid=root;Pwd=;"))
        {
            string query = "INSERT INTO user_landscape(landscape_id, user_account_id) VALUES (@LandscapeId,@userId);";
            rows = connection.ExecuteScalar<int>(query, param: user);
        }
        return rows;
    }
    public int AgeSpanMatch(User user)
    {
        int rows = 0;
        using (MySqlConnection connection = new MySqlConnection($"Server=localhost;Database=2gether;Uid=root;Pwd=;"))
        {
            string query = "INSERT INTO user_age(age_id, user_account_id) VALUES (@AgeId,@userId);";
            rows = connection.ExecuteScalar<int>(query, param: user);
        }
        return rows;
    }

}