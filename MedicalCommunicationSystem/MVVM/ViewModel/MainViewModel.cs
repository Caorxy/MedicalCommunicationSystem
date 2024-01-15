using MedicalCommunicationSystem.Core;
using MedicalCommunicationSystem.EventAggregator;

namespace MedicalCommunicationSystem.MVVM.ViewModel;

public class MainViewModel : ObservableObject
{
    public RelayCommand LoginViewCommand { get; set; }
    public RelayCommand DoctorPanelViewCommand { get; set; }
    public RelayCommand PatientPanelViewCommand { get; set; }
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
        
        // Nasluchuje eventow od agregatora
        Mediator.GetInstance().Event += (_, e) =>
        {
            CurrentView = e switch
            {
                // Sprawdza czy wiadomosc jest przeznaczona dla niego
                MediatorMessage { MessageType: "OpenDoctorPanel" } => DoctorPanelVm,
                MediatorMessage { MessageType: "OpenPatientPanel" } => PatientPanelVm,
                _ => CurrentView
            };
        };       
        
        LogoutCommand = new RelayCommand(_ =>
        {
            CurrentView = LoginVm;
        });
    }
}