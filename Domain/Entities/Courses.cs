using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Courses
{
    [StringLength(30,MinimumLength = 3,ErrorMessage = "Title must be between 3 and 30 characters")]
    public string Title {  get; set; }
    public string Description {  get; set; }
    public decimal Price {  get; set; } 
    public bool IsActive {  get; set; }
    
    //navigation
    public int? TeacherId {  get; set; }
    public Teachers? Teacher {  get; set; }
}