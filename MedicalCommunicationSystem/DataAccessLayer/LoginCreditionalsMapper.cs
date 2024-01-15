using System.Data.SqlClient;
using MedicalCommunicationSystem.MVVM.Model;

namespace MedicalCommunicationSystem.DataAccessLayer;

public class LoginCredentialsMapper
{
    public static LoginCredentials? Map(SqlDataReader reader)
    {
        return new LoginCredentials
        {
            UserId = (int)reader["UserID"],
            Salt = (string)reader["Salt"],
            Password = (string)reader["Password"],
            TypeId = (int)reader["TypeID"]
        };
    }
}
