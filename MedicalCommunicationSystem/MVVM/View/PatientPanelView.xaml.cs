using System.Windows;
using System.Windows.Controls;

namespace MedicalCommunicationSystem.MVVM.View;

public partial class PatientPanelView : UserControl
{
    public PatientPanelView()
    {
        InitializeComponent();
        DataContext = Application.Current.MainWindow?.DataContext;
    }
}