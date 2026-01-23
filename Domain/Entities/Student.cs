using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Student : BaseEntities
{
    [StringLength(40,MinimumLength = 3,ErrorMessage = "FirstName ai 40 to 3 ")]
    public required string FirstName { get; set; } = string.Empty;
    [StringLength(40,MinimumLength = 3,ErrorMessage = "LastName ai 40 to 3 ")]
    public string LastName  { get; set; } = string.Empty;

    public DateTime BirthDate { get; set; } = DateTime.UtcNow;
    [EmailAddress]
    public string Email  { get; set; } = string.Empty;
    [Phone]
    public string Phone { get; set; }
    
    
    public List<StudentGroups>? StudentGroups { get; set; }

}