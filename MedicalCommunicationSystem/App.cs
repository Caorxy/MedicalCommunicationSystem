using System.Windows;


namespace MedicalCommunicationSystem;

public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        ServiceLocator.RegisterServices();
    }
}

