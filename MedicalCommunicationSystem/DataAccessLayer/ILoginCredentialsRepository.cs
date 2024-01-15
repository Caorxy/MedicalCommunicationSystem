using MedicalCommunicationSystem.MVVM.Model;

namespace MedicalCommunicationSystem.DataAccessLayer;

public interface ILoginCredentialsRepository
{
    public LoginCredentials? GetByUsername(string username);
    public string? GetHashedString(string password, string? salt);
    public void Update(LoginCredentials loginCredentials);
    public void Delete(LoginCredentials loginCredentials);
}