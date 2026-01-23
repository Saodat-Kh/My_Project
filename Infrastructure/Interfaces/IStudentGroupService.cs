using Domain.Dto.Groups;
using Domain.Dto.Student;
using Domain.Dto.StudentGroups;
using Domain.Enum;
using Domain.Responses;

namespace Infrastructure.Interfaces;

public interface IStudentGroupService
{
    Response<string> CreateStudent(CreateStudentGroupDto dto);
    Response<string> DeleteStudent(string studentId);
    Response<List<GetStudentDto>> GetAllStudents();
    Response<string>   GiveAGradeToTheStudent(ActiveStatus status);
    Response<string> CreateStudentGroup(CreateStudentGroupDto dto);
    Response<string> DeleteStudentGroup(string groupId);
    Response<string> GiveAGradeToTheStudent(GetStudentGroupDto dto);
    Response<List<GetStudentGroupDto>> GetAllStudentGroups();
}




 



 