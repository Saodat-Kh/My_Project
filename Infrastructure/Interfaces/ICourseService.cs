using Domain.Dto.Courses;
using Domain.Dto.Teachers;
using Domain.Entities;
using Domain.Responses;

namespace Infrastructure.Interfaces;

public interface ICourseService
{
    Response<string> CreateCourses(CreateCourseDto dto);
    Response<string> UpdateCourses(int id, UpdateCourseDto dto);
    Response<string> DeleteCourses(int id);
    Response<List<GetCourseDto>> GetAllCourses();
    Response<GetCourseDto> GetCourseById(int id);
    Response<GetCourseDto> GetCourseFilterByPrice(decimal price);
    Response<List<GetCourseWithTeacher>> GetCourseWithTeacher();                                                                                                                                                                                                                                                                                          
}