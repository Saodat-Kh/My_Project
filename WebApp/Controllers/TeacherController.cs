using Domain.Dto.Teachers;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
[ApiController]
[Route("api/[controller]")]
public class TeacherController(ITeacherService service) : Controller
{
    [HttpPost]
    public IActionResult CreateTeacher(CreateTeacherDto dto)
    {
        var res = service.CreateTeacher(dto);
        return StatusCode(res.StatusCode, res);
    }

    [HttpGet]
    public IActionResult GetAllTeachers()
    {
        var res = service.GetAllTeachers();
        return StatusCode(res.StatusCode, res);
    }

    [HttpGet("{id}")]
    public IActionResult GetTeacherById(int id)
    {
        var res = service.GetTeacherById(id);
        return StatusCode(res.StatusCode, res);
    }

    [HttpPut]
    public IActionResult UpdateTeacher(int id, UpdateTeacherDto dto)
    {
        var res = service.UpdateTeacher(id, dto);
        return StatusCode(res.StatusCode, res);
    }

    [HttpDelete]
    public IActionResult DeleteTeacher(int id)
    {
        var res = service.DeleteTeacher(id);
        return StatusCode(res.StatusCode, res);
    }

    [HttpGet("IsActive")]
    public IActionResult GetTeacherIsActive()
    {
        var res = service.GetAllTeachersWithCoursesIsActive();
        return StatusCode(res.StatusCode, res);
    }
}