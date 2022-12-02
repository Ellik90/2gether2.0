using Dapper;
using MySqlConnector;
using BASE;
using System.Collections.Generic;
namespace DATABASE;

public class UserDB : IUserHandeler
{
    public int CreateUser(User user)
    {
        int rows = 0;
        using (MySqlConnection connection = new MySqlConnection($"Server=localhost;Database=2gether;Uid=root;Pwd=;"))
        {
            string query = "INSERT INTO user_account(first_name, last_name, gender, age, personal_number, email, pass_word,land_scape_id)" +
            "VALUES(@Name,@LastName,@Gender,@Age,@PersonalNumber,@Email,@PassWord,@landScapeId);";
            rows = connection.ExecuteScalar<int>(query, param : user);
        }
        return rows;
    }

    public int DeleteUser(User user)
    {
        int rows = 0;
        using (MySqlConnection connection = new MySqlConnection($"Server=localhost;Database=2gether;Uid=root;Pwd=;"))
        {
            string query = "DELETE FROM user_account WHERE id = @id";
            rows = connection.ExecuteScalar<int>(query, param: user);
        }
        return rows;
    }

    public int UpdateUserEmail(User user, string userEmail)
    {
        int rows = 0;
        using (MySqlConnection connection = new MySqlConnection($"Server=localhost;Database=Blocket_clone;Uid=root;Pwd=;"))
        {
            string? query = "UPDATE user_account SET email = @UserEmail WHERE id = @id";
            rows = connection.ExecuteScalar<int>(query, param: new { @userEmail = userEmail, @id = user.Id });
        }
        return rows;
    }


    public int UpdateUserPassword(User user)
    {
        int rows = 0;
        using (MySqlConnection connection = new MySqlConnection($"Server=localhost;Database=2gether;Uid=root;Pwd=;"))
        {
            string query = "UPDATE user_account SET pass_word = @PassWord WHERE id = @id";
            rows = connection.ExecuteScalar<int>(query, param: user);
        }
        return rows;
    }

    public bool UserEmailExists(string email)
    {
        bool rows = true;
        using (MySqlConnection connection = new MySqlConnection($"Server=localhost;Database=2gether;Uid=root;Pwd=;"))
        {
            string query = "SELECT * FROM user_account WHERE email = @email";
            rows = connection.ExecuteScalar<bool>(query, new { @email = email });
        }
        return rows;
    }
    public bool UserPersonalNumberExists(string personalNumber)
    {
        bool rows = true;
        using (MySqlConnection connection = new MySqlConnection($"Server=localhost;Database=2gether;Uid=root;Pwd=;"))
        {
            string query = "SELECT * FROM user_account WHERE personal_number = @PersonalNumber";
            rows = connection.ExecuteScalar<bool>(query, new { @personalNumber = personalNumber });
        }
        return rows;
    }

    public int UserLogInExists(User user)
    {
        int id = 0;
        using (MySqlConnection connection = new MySqlConnection($"Server=localhost;Database=2gether;Uid=root;Pwd=;"))
        {
            string? query = "SELECT id FROM user_account WHERE email = @email AND pass_word = @password;";
            id = connection.ExecuteScalar<int>(query, param: user);
            return id;
        }
    }

    public List<User> GetAllUsers()
    {
        List<User> users = new();
        using (MySqlConnection connection = new MySqlConnection($"Server=localhost;Database=2gether;Uid=root;Pwd=;"))
        {
            string? query = "SELECT id AS 'id', personal_number AS 'personalNumber',first_name AS 'name', email AS 'email', pass_word AS 'password', landscape.name AS 'landscape' " +
                       "FROM user_account INNER JOIN landscape ON user_account.land_scape_id = landscape.id;";
            users = connection.Query<User>(query).ToList();
            return users;
        }
    }
    public int Update(User user)
    {
        int id = 0;
        using (MySqlConnection connection = new MySqlConnection($"Server=localhost;Database=2gether;Uid=root;Pwd=;"))
        {
            string? query = "UPDATE user_account SET about_me = @AboutMe, pass_word = @PassWord, email = @Email;";
            id = connection.ExecuteScalar<int>(query, param: user);
            return id;
        }
    }
    public int GetAllUsersLandscapes(User user)
    {
        int id = 0;
        using (MySqlConnection connection = new MySqlConnection($"Server=localhost;Database=2gether;Uid=root;Pwd=;"))
        {
            string query = " SELECT id AS 'id', personal_number AS 'personalNumber',first_name AS 'name', email AS 'email', pass_word AS 'password', landscape.name AS 'landscape'" +
            "FROM user_account INNER JOIN landscape ON user_account.land_scape_id = landscape.id;";
            id = connection.ExecuteScalar<int>(query, param : user);
            return id;
        }

    }


    public User GetUser(int id)
    {
        User user = new();
        using (MySqlConnection connection = new MySqlConnection($"Server=localhost;Database=2gether;Uid=root;Pwd=;"))
        {
            string query = " SELECT u.id AS 'id', u.personal_number AS 'personalNumber', u.first_name AS 'name', u.email AS 'email', u.pass_word AS 'password', l.name AS 'landscape'" +
            "FROM user_account u INNER JOIN landscape l ON u.land_scape_id = l.id WHERE u.id = @id;";
            user = connection.QuerySingle<User>(query, new{@id = id});
            return user;
        }

    }
}



// public List<User> GetUsers(User user)
// {
//     List<User> users = new();

//     using (MySqlConnection connection = new MySqlConnection($"Server=localhost;Database=2gether;Uid=root;Pwd=;"))
//     {
//         string query = "SELECT id AS 'id', personal_number AS 'personalNumber',first_name AS 'name', email AS 'email', pass_word AS 'password' FROM user_account;";
//         users = connection.Query<user>(query).ToList();
//         return users;
//     }
// }

