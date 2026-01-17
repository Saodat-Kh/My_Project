using Domain.Dto.Teachers;
using Domain.Responses;

namespace Infrastructure.Interfaces;

public interface ITeacherService
{
    Response<string> CreateTeacher(CreateTeacherDto dto);
    Response<string> UpdateTeacher(int id,UpdateTeacherDto dto);
    Response<string> DeleteTeacher(int id);
 
    Response<List<GetTeacherDto>> GetAllTeachers();
    Response<GetTeacherDto> GetTeacherById(int id);
    Response<List<GetTeacherWithCourse>>  GetAllTeachersWithCoursesIsActive();
    Response<GetTeacherDto> GetTeacherSearchByName(string name);
    
}