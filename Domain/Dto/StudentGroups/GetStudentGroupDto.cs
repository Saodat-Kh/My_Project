using Domain.Dto.Groups;
using Domain.Dto.Student;

namespace Domain.Dto.StudentGroups;

public class GetStudentGroupDto
{
    public List<GetStudentDto> Students { get; set; }
    public List<GetGroupDto> Groups { get; set; }
    
    
}