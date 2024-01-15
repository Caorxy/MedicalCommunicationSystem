using System.Security.Cryptography;
using System.Text;
using MedicalCommunicationSystem.DataAccessLayer;

namespace MedicalCommunicationSystem.Services;

public class AuthenticationService(LoginCredentialsRepository repository)
{
    public bool ValidateUser(string userId, string password, string typeId)
    {
        var loginCredentials = repository.GetByUserId(userId);
        return loginCredentials?.TypeId.ToString() == typeId && VerifyHashedPassword(loginCredentials.Password, password, loginCredentials.Salt);
    }

    public void ChangePassword(string username, string oldPassword, string newPassword)
    {
        var loginCredentials = repository.GetByUserId(username);
        if (loginCredentials != null)
        {
            if (VerifyHashedPassword(loginCredentials.Password, oldPassword, loginCredentials.Salt))
            {
                var hashedPassword = HashPassword(newPassword,loginCredentials.Salt);
                loginCredentials.Password = hashedPassword;
                repository.Update(loginCredentials);
            }
            else
            {
                throw new Exception("Old password is incorrect");
            }
        }
        else
        {
            throw new Exception("User not found");
        }
    }

    public void DeleteUser(string username, string password)
    {
        var loginCredentials = repository.GetByUserId(username);
        if (loginCredentials != null)
        {
            if (VerifyHashedPassword(loginCredentials.Password, password, loginCredentials.Salt))
            {
                repository.Delete(loginCredentials);
            }
            else
            {
                throw new Exception("Password is incorrect");
            }
        }
        else
        {
            throw new Exception("User not found");
        }
    }
    private string? HashPassword(string password, string? salt)
    {
        return repository.GetHashedString(password, salt);
    }

    private bool VerifyHashedPassword(string? hashedPassword, string password,  string? salt)
    {
        return hashedPassword == HashPassword(password, salt);
    }
}
