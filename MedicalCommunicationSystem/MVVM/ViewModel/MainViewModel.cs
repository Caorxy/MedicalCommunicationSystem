using MedicalCommunicationSystem.Core;

namespace MedicalCommunicationSystem.MVVM.ViewModel;

public class MainViewModel : ObservableObject
{
    public RelayCommand HomeViewCommand { get; set; }
    public RelayCommand LoginViewCommand { get; set; }
    public RelayCommand SubmitCommand { get; set; }
    public LoginViewModel LoginVm { get; set; }
    public HomeViewModel HomeVm { get; set; }
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
        HomeVm = new HomeViewModel();
        CurrentView = LoginVm;
        
        HomeViewCommand = new RelayCommand(_ =>
        {
            CurrentView = HomeVm;
        });
        
        LoginViewCommand = new RelayCommand(_ =>
        {
            CurrentView = LoginVm;
        });
        
        SubmitCommand = new RelayCommand(_ =>
        {
            if (LoginVm.OpacitySide[0] == LoginVm.OpacitySide[1])
                LoginVm.ChooseModeVisibility = "Visible";
            else
                CurrentView = HomeVm;
        });
    }
}