namespace MedicalCommunicationSystem.EventAggregator;

public abstract class MediatorMessage
{
    public string? MessageType { get; set; }
    
    public class OpenDoctorPanelMessage : MediatorMessage;
    public class OpenPatientPanelMessage : MediatorMessage;

}
