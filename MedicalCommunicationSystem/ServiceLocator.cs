using System.Data.SqlClient;
using MedicalCommunicationSystem.DataAccessLayer;
using MedicalCommunicationSystem.Services;
using Unity;

namespace MedicalCommunicationSystem;

public static class ServiceLocator
{
    private static UnityContainer? _container;
    private const string ConnectionString = "";
    
    public static void RegisterServices()
    {
        _container = new UnityContainer();
        var loginCredentialsGateway = new LoginCredentialsGateway(ConnectionString);
        var loginCredentialsRepository = new LoginCredentialsRepository(loginCredentialsGateway);
        var authenticationService = new AuthenticationService(loginCredentialsRepository);

        _container.RegisterInstance(authenticationService);
    }

    public static T GetService<T>()
    {
        return _container.Resolve<T>();
    }
}
