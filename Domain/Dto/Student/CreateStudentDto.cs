using System.ComponentModel.DataAnnotations;

namespace Domain.Dto.Student;

public class CreateStudentDto
{
    [StringLength(40,MinimumLength = 3,ErrorMessage = "FirstName ai 40 to 3 ")]
    public required string FirstName { get; set; } = string.Empty;
    [StringLength(40,MinimumLength = 3,ErrorMessage = "LastName ai 40 to 3 ")]
    public string LastName  { get; set; } = string.Empty;
    [EmailAddress]
    public string Email  { get; set; } = string.Empty;
    [Phone]
    public string Phone { get; set; }

}