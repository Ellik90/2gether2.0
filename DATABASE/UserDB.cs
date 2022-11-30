namespace DATABASE;
using Dapper;
using MySqlConnector;
using BASE;
using System.Collections.Generic;

public class UserDB: IUserHandeler
{
    public int CreateUser(User user)
    {
        int rows = 0;
        using (MySqlConnection connection = new MySqlConnection($"Server=localhost;Database=2gether;Uid=root;Pwd=;"))
        {
            string query = "INSERT INTO user_account(first_name, last_name, gender, age, personal_number, email, pass_word)VALUES(@Name,@LastName,@Gender,@Age,@PersonalNumber,@Email,@PassWord);";
            rows = connection.ExecuteScalar<int>(query, param: user);
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

    public List<User> GetUser()
    {
        throw new NotImplementedException();
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
            rows = connection.ExecuteScalar<bool>(query, new { @personalNumber = personalNumber});
        }
        return rows;
    }

    public int UserLogInExists(User user)
    {
        int id = 0;
        using (MySqlConnection connection = new MySqlConnection($"Server=localhost;Database=2gether;Uid=root;Pwd=;"))
        {
            string? query = "SELECT * FROM user_account WHERE email = @email AND pass_word = @password; SELECT LAST_INSERT_ID() ";
            id = connection.ExecuteScalar<int>(query, param: user);
            return id;
        }
    }
}



    // public List<User> GetUsers(User user)
    // {
    //     List<User> users = new();

    //     using (MySqlConnection connection = new MySqlConnection($"Server=localhost;Database=Blocket_clone;Uid=root;Pwd=;"))
    //     {
    //         string query = "SELECT id AS 'id', personal_number AS 'personalNumber',first_name AS 'name', email AS 'email', pass_word AS 'password' FROM admins;";
    //         users = connection.Query<user>(query).ToList();
    //         return users;
    //     }
    // }

