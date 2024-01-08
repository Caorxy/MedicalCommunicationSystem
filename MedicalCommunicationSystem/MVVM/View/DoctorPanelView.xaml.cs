using System.Windows;
using System.Windows.Controls;

namespace MedicalCommunicationSystem.MVVM.View;

public partial class DoctorPanelView : UserControl
{
    public DoctorPanelView()
    {
        InitializeComponent();
        DataContext = Application.Current.MainWindow?.DataContext;
    }
}