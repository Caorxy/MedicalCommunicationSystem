using System.Windows;
using System.Windows.Controls;

namespace MedicalCommunicationSystem.MVVM.View;

public partial class LoginView : UserControl
{
    public LoginView()
    {
        InitializeComponent();
        DataContext = Application.Current.MainWindow?.DataContext;
    }
}