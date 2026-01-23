using Domain.Dto.Student;
using Domain.Responses;

namespace Infrastructure.Interfaces;

public interface IStudentService
{
    Response<string> CreateStudent(CreateStudentDto dto);
    Response<string> UpdateStudent(int id, UpdateStudentDto dto);
    Response<string> DeleteStudent(int id);
    Response<List<GetStudentDto>> GetAllStudent();
    Response<GetStudentDto> GetStudentById(int id);
    Response<List<GetStudentDto>> GetStudentByDelete();
    Response<string> RestoringDeletedFiles(int id);
}