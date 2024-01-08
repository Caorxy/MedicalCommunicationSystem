using MedicalCommunicationSystem.Core;

namespace MedicalCommunicationSystem.MVVM.ViewModel;

public class LoginViewModel : ObservableObject
{
    private string[] _opacitySide;
    private string _chooseModeVisibility;
    
    public RelayCommand ChooseDoctorCommand { get; set; }
    public RelayCommand ChoosePatientCommand { get; set; }
    
    public string ChooseModeVisibility
    {
        get => _chooseModeVisibility;
        set
        {
            _chooseModeVisibility = value;
            OnPropertyChanged();
        }
    }
    
    public string[] OpacitySide
    {
        get => _opacitySide;
        private set
        {
            _opacitySide = value;
            OnPropertyChanged();
        }
    }

    public LoginViewModel()
    {
        _opacitySide = ["0.25","0.25"];
        _chooseModeVisibility = "Collapsed";
            
        ChooseDoctorCommand = new RelayCommand(_ =>
        {
            OpacitySide = ["1","0.25"];
        });
        
        ChoosePatientCommand = new RelayCommand(_ =>
        {
            OpacitySide = ["0.25","1"];
        });        
        
    }
}