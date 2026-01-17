using System.ComponentModel.DataAnnotations;

namespace Domain.Dto.Teachers;

public class CreateTeacherDto
{
    [StringLength(30,MinimumLength = 3,ErrorMessage = "Name must be between 3 and 30 characters")]
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }   
    [Phone]
    public string Phone { get; set; }
    public string Specialization {  get; set; }
    public int ExperienceYears {  get; set; }
}