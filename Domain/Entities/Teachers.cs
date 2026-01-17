using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Teachers : BaseEntities
{
    [StringLength(30,MinimumLength = 3,ErrorMessage = "Name must be between 3 and 30 characters")]
    public required string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }   
    [Phone]
    public string Phone { get; set; }
    public string Specialization {  get; set; }
    public int ExperienceYears {  get; set; }
    public bool IsDeleted { get; set; }
 
    
 
    
    //navigation
    public List<Courses> Courses { get; set; }
}