using Domain.Dto.Courses;
using Domain.Dto.Groups;
using Domain.Responses;

namespace Infrastructure.Interfaces;

public interface IGroupService
{
    Response<List<GetGroupDto>> GetAllGroups();
    Response<GetGroupDto> GetGroupById(int groupId);
    Response<List<GetGroupWithCourse>>  GetGroupWithCourseByCourseId(int courseId);
    Response<string> CreateGroup(CreateGroupDto dto);
    Response<string> UpdateGroup(int groupId, UpdateGroupDto dto);
    Response<string> DeleteGroup(int groupId);
    Response<string> UpdateGroupByIdWithStart(int gId, UpdateGroupDto dtoS);
    
    
    
    
}