using Domain.Dto.Student;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
[ApiController]
[Route("api/[controller]")]
public class StudentController(IStudentService service) : Controller
{
    [HttpPost]
    public IActionResult CreateStudent(CreateStudentDto dto)
    {
        var res = service.CreateStudent(dto);
        return StatusCode(res.StatusCode, res);
    }

    [HttpGet]
    public IActionResult GetAllStudents()
    {
        var res = service.GetAllStudent();
        return StatusCode(res.StatusCode, res);
    }

    [HttpPut]
    public IActionResult UpdateStudent(int id, UpdateStudentDto dto)
    {
        var res = service.UpdateStudent(id, dto);
        return StatusCode(res.StatusCode, res);
    }

    [HttpDelete]
    public IActionResult DeleteStudent(int id)
    {
        var res = service.DeleteStudent(id);
        return StatusCode(res.StatusCode, res);
    }

    [HttpGet("id")]
    public IActionResult GetStudentById(int id)
    {
        var res = service.GetStudentById(id);
        return StatusCode(res.StatusCode, res);
    }

    [HttpPut("RestoringDeletedFiles")]
    public IActionResult RestoringDeletedFiles(int id)
    {
        var res = service.RestoringDeletedFiles(id);
        return StatusCode(res.StatusCode, res);
    }

    [HttpGet("ByDalete")]
    public IActionResult GetStudentByDelete()
    {
        var res = service.GetStudentByDelete();
        return StatusCode(res.StatusCode, res);
    }
    
    
    
    
    
    
}