using System.ComponentModel.DataAnnotations;
using Domain.Dto.Teachers;

namespace Domain.Dto.Courses;

public class GetCourseWithTeacher
{ 
    public string Title {  get; set; } 
    public string Description {  get; set; }
    public decimal Price {  get; set; } 
    public bool IsActive {  get; set; }
    
    public int? TeacherId {  get; set; }
    public GetTeacherDto? Teacher {  get; set; }
}