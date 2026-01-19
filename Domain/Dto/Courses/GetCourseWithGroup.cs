using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Domain.Dto.Groups;

namespace Domain.Dto.Courses;

public class GetCourseWithGroup
{
    [StringLength(30,MinimumLength = 3,ErrorMessage = "Title must be between 3 and 30 characters")]
    public required string Title {  get; set; }
    public string Description {  get; set; }
    public decimal Price {  get; set; } 
    public bool IsActive {  get; set; }
    
    public List<GetGroupDto>? Groups {  get; set; }
}