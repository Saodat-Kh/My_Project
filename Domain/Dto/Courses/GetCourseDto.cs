using System.ComponentModel.DataAnnotations;

namespace Domain.Dto.Courses;

public class GetCourseDto
{
    public int  Id {  get; set; }
    public DateTime CreatedAt { get; set; }
    [StringLength(30,MinimumLength = 3,ErrorMessage = "Title must be between 3 and 30 characters")]
    public string Title {  get; set; }
    public string Description {  get; set; }
    public decimal Price {  get; set; }
    public bool IsActive {  get; set; }
}