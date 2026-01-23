using Domain.Dto.Groups;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
[ApiController]
[Route("api/[controller]")]
public class GroupController(IGroupService service) : Controller
{
    [HttpPost]
    public IActionResult CreateGroup(CreateGroupDto dto)
    {
        var ree = service.CreateGroup(dto);
        return StatusCode(ree.StatusCode, ree);
    }

    [HttpPut]
    public IActionResult UpdateGroup(int groupId,UpdateGroupDto dto)
    {
        var res = service.UpdateGroup(groupId,dto);
        return StatusCode(res.StatusCode, res);
    }

    [HttpPut("WithStrart")]
    public IActionResult UpdateGroupByIdWithStart(int gId, UpdateGroupDto dtoS)
    {
        var res = service.UpdateGroupByIdWithStart(gId, dtoS);
        return StatusCode(res.StatusCode, res);
    }

    [HttpDelete]
    public IActionResult DeleteGroup(int groupId)
    {
        var res = service.DeleteGroup(groupId);
        return StatusCode(res.StatusCode, res);
    }

    [HttpGet]
    public IActionResult GetAllGroups()
    {
        var res = service.GetAllGroups();
        return StatusCode(res.StatusCode, res);
    }

    [HttpGet("ById")]
    public IActionResult GetGroupById(int groupId)
    {
        var res = service.GetGroupById(groupId);
        return StatusCode(res.StatusCode, res);
    }

    [HttpGet("WithCourse")]
    public IActionResult GetGroupWithCourseByCourseId(int courseId)
    {
        var res = service.GetGroupWithCourseByCourseId(courseId);
        return StatusCode(res.StatusCode, res);
    }
    
}