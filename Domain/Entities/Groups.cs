using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Groups : BaseEntities
{
    [StringLength(40,MinimumLength = 3,ErrorMessage = "Name must be between 3 and 40 characters")]
    public required string Name { get; set; }
    public DateTime StartDate { get; set; } = DateTime.UtcNow;
    public DateTime EndDate { get; set; } = DateTime.UtcNow;
    public bool IsStarted { get; set; }
    
    
    //navigation
    public string? CourseId { get; set; }
    public Courses?  Course { get; set; }
    
    public List<StudentGroups>? StudentGroups { get; set; }
}