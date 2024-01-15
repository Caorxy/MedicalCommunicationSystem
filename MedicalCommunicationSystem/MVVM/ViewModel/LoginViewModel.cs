using MedicalCommunicationSystem.Core;
using MedicalCommunicationSystem.EventAggregator;
using MedicalCommunicationSystem.Services;

namespace MedicalCommunicationSystem.MVVM.ViewModel;

public class LoginViewModel : ObservableObject
{
    private string[] _opacitySide;
    private string _chooseModeVisibility;
    private string _wrongDataBoxVisibility;
    private string _userId;
    private string _typeId;
    private string _password;

    public AuthenticationService AuthenticationService = ServiceLocator.GetService<AuthenticationService>();
    
    public RelayCommand ChooseDoctorCommand { get; set; }
    public RelayCommand ChoosePatientCommand { get; set; }
    public RelayCommand HideWrongDataBoxCommand { get; set; }
    public RelayCommand SubmitCommand { get; set; }
    
    public string ChooseModeVisibility
    {
        get => _chooseModeVisibility;
        set
        {
            _chooseModeVisibility = value;
            OnPropertyChanged();
        }
    }    
    
    public string UserId
    {
        get => _userId;
        set
        {
            _userId = value;
            OnPropertyChanged();
        }
    }        
    
    public string TypeId
    {
        get => _typeId;
        set
        {
            _typeId = value;
            OnPropertyChanged();
        }
    }    
    
    public string Password
    {
        get => _password;
        set
        {
            _password = value;
            OnPropertyChanged();
        }
    }    
    
    public string WrongDataBoxVisibility
    {
        get => _wrongDataBoxVisibility;
        set
        {
            _wrongDataBoxVisibility = value;
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
        _wrongDataBoxVisibility = "Collapsed";
        _userId = "";
        _typeId = "";
        _password = "";
            
        ChooseDoctorCommand = new RelayCommand(_ =>
        {
            TypeId = "2";
            OpacitySide = ["1","0.25"];
        });
        
        ChoosePatientCommand = new RelayCommand(_ =>
        {
            TypeId = "1";
            OpacitySide = ["0.25","1"];
        });           
        
        HideWrongDataBoxCommand = new RelayCommand(_ =>
        {
            WrongDataBoxVisibility = "Collapsed";
        });       
        
        SubmitCommand = new RelayCommand(_ =>
        {
            if (string.IsNullOrEmpty(TypeId))
                ChooseModeVisibility = "Visible";
            else
            {
                if (AuthenticationService.ValidateUser(UserId, Password, TypeId))
                {
                    if (TypeId == "2")
                        Mediator.GetInstance().OnEvent(this, new MediatorMessage.OpenDoctorPanelMessage
                        {
                            MessageType = "OpenDoctorPanel",
                        });
                    else
                        Mediator.GetInstance().OnEvent(this, new MediatorMessage.OpenPatientPanelMessage
                        {
                            MessageType = "OpenPatientPanel",
                        });
                }
                else
                {
                    WrongDataBoxVisibility = "Visible";
                }
            }
        });   
        
    }
}