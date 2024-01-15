using System.ComponentModel.DataAnnotations;

namespace MedicalCommunicationSystem.MVVM.Model;

public class LoginCredentials
{
    [Key]
    public int UserId { get; set; }

    [Required]
    [StringLength(50)]
    public string? Salt { get; set; }

    [Required]
    [StringLength(50)]
    public string? Password { get; set; }

    [Required]
    public int TypeId { get; set; }
}