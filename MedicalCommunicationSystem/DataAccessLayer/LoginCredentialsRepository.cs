using MedicalCommunicationSystem.MVVM.Model;

namespace MedicalCommunicationSystem.DataAccessLayer;

public class LoginCredentialsRepository(LoginCredentialsGateway gateway)
{
    public LoginCredentials? GetByUserId(string userId)
    {
        return gateway.GetByUserId(userId);
    }    
    
    public string? GetHashedString(string password, string? salt)
    {
        return gateway.GetHashedString( password,  salt);
    }

    public void Update(LoginCredentials loginCredentials)
    {
        gateway.Update(loginCredentials);
    }

    public void Delete(LoginCredentials loginCredentials)
    {
        gateway.Delete(loginCredentials);
    }
}
