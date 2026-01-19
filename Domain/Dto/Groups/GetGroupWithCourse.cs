using System.ComponentModel.DataAnnotations;
using Domain.Dto.Courses;

namespace Domain.Dto.Groups;

public class GetGroupWithCourse
{
    [StringLength(40,MinimumLength = 3,ErrorMessage = "Name must be between 3 and 40 characters")]
    public required string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsStarted { get; set; }
    
    //navigation
    public string? CourseId { get; set; }
    public GetCourseDto?  Course { get; set; }
}