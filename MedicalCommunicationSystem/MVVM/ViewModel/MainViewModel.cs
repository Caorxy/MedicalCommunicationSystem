using MedicalCommunicationSystem.Core;

namespace MedicalCommunicationSystem.MVVM.ViewModel;

public class MainViewModel : ObservableObject
{
    public RelayCommand LoginViewCommand { get; set; }
    public RelayCommand DoctorPanelViewCommand { get; set; }
    public RelayCommand PatientPanelViewCommand { get; set; }
    public RelayCommand SubmitCommand { get; set; }
    public RelayCommand LogoutCommand { get; set; }
    public LoginViewModel LoginVm { get; set; }
    public DoctorPanelViewModel DoctorPanelVm { get; set; }
    public PatientPanelViewModel PatientPanelVm { get; set; }
    
    private object? _currentView;

    public object? CurrentView
    {
        get => _currentView;
        set
        {
            _currentView = value;
            OnPropertyChanged();
        }
    }

    public MainViewModel()
    {
        LoginVm = new LoginViewModel();
        DoctorPanelVm = new DoctorPanelViewModel();
        PatientPanelVm = new PatientPanelViewModel();
        CurrentView = LoginVm;
        
        LoginViewCommand = new RelayCommand(_ =>
        {
            CurrentView = LoginVm;
        });   
        
        DoctorPanelViewCommand = new RelayCommand(_ =>
        {
            CurrentView = DoctorPanelVm;
        });        
        
        PatientPanelViewCommand = new RelayCommand(_ =>
        {
            CurrentView = PatientPanelVm;
        });
        
        SubmitCommand = new RelayCommand(_ =>
        {
            if (LoginVm.OpacitySide[0] == LoginVm.OpacitySide[1])
                LoginVm.ChooseModeVisibility = "Visible";
            else if (LoginVm.OpacitySide[0] == "1")
                CurrentView = DoctorPanelVm;
            else
                CurrentView = PatientPanelVm;
        });   
        
        LogoutCommand = new RelayCommand(_ =>
        {
            CurrentView = LoginVm;
        });
    }
}