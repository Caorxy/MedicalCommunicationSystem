using System.Data.SqlClient;
using MedicalCommunicationSystem.MVVM.Model;

namespace MedicalCommunicationSystem.DataAccessLayer;

public class LoginCredentialsGateway(string connectionString)
{
    public LoginCredentials? GetByUserId(string userId)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            var command = new SqlCommand("SELECT * FROM LoginCredentials WHERE UserId = @userId", connection);
            command.Parameters.AddWithValue("@UserId", userId);
            using (var reader = command.ExecuteReader())
            {
                return reader.Read() ? LoginCredentialsMapper.Map(reader) : null;
            }
        }
    }

    public string? GetHashedString(string password, string? salt){
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            var exec = "SELECT CAST(HASHBYTES('SHA2_512','" + password + "' + '" + salt + "') AS VARCHAR(50))";
            var command =
                new SqlCommand(exec, connection);
            using (var reader = command.ExecuteReader())
            {
                var x = reader.Read() ? reader.GetString(0) : null;
                return x;
            }
        }
    }

public void Update(LoginCredentials loginCredentials)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            var command = new SqlCommand("UPDATE LoginCredentials SET Password = @Password WHERE UserID = @UserID", connection);
            command.Parameters.AddWithValue("@Password", loginCredentials.Password);
            command.Parameters.AddWithValue("@UserID", loginCredentials.UserId);
            command.ExecuteNonQuery();
        }
    }

    public void Delete(LoginCredentials loginCredentials)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            var command = new SqlCommand("DELETE FROM LoginCredentials WHERE UserID = @UserID", connection);
            command.Parameters.AddWithValue("@UserID", loginCredentials.UserId);
            command.ExecuteNonQuery();
        }
    }
}
