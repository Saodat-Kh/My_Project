using System.ComponentModel.DataAnnotations;

namespace Domain.Dto.Teachers;

public class GetTeacherDto
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    [StringLength(30,MinimumLength = 3,ErrorMessage = "Name must be between 3 and 30 characters")]
    public string FirstName { get; set; }
    [StringLength(40,MinimumLength = 3,ErrorMessage = "Name must be between 3 and 40 characters")]
    public string LastName { get; set; }
    [EmailAddress]
    public string Email { get; set; }   
    [Phone]
    public string Phone { get; set; }
    public string Specialization {  get; set; }
    public int ExperienceYears {  get; set; }
}