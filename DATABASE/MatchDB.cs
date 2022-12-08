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
 public List<User> GetUsersByLandscapeAndAge(User user)
    {
        List<User> matchUsers = new();
        
        using (MySqlConnection connection = new MySqlConnection($"Server=localhost;Database=2gether;Uid=root;Pwd=;"))
        {
            string query = "SELECT u.id AS 'Id', u.first_name AS 'Name', u.last_name AS 'LastName' FROM user_account u INNER JOIN user_account u2 " + 
            "INNER JOIN user_landscape ul ON u.land_scape_id = ul.landscape_id INNER JOIN user_age ua " + 
            "ON ua.user_account_id = u2.id INNER JOIN age a ON a.id = ua.age_id WHERE u2.id = @Id " + 
            "AND u.age > a.lower_age AND u.age < a.upper_age AND u.id != @Id GROUP BY u.id;";
            matchUsers = connection.Query<User>(query, param: user).ToList();
        }
        return matchUsers;
    }
}