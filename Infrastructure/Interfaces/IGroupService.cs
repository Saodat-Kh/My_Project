using Domain.Dto.Courses;
using Domain.Dto.Groups;
using Domain.Responses;

namespace Infrastructure.Interfaces;

public interface IGroupService
{
    Response<List<GetGroupDto>> GetAllGroups();
    Response<GetGroupDto> GetGroupById(int groupId);
    Response<GetGroupWithCourse>  GetGroupWithCourseByCourseId(int courseId);
    Response<string> CreateGroup(CreateGroupDto dto);
    Response<string> UpdateGroup(int groupId, UpdateGroupDto dto);
    Response<string> DeleteGroup(int groupId);
    Response<string> UpdateCourseByIdWithStart(int gId, UpdateCourseDto dto);
    
    
    
    
}