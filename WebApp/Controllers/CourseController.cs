using Domain.Dto.Courses;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
[ApiController]
[Route("api/course")]
public class CourseController(ICourseService service ) : Controller
{
    [HttpPost]
    public IActionResult CreateCourse(CreateCourseDto dto)
    {
        var res = service.CreateCourses(dto);
        return StatusCode(res.StatusCode, res);
    }

    [HttpGet]
    public IActionResult GetAllCourses()
    {
        var res = service.GetAllCourses();
        return StatusCode(res.StatusCode, res);
    }

    [HttpGet("id")]
    public IActionResult GetCourseById(int id)
    {
        var res = service.GetCourseById(id);
        return StatusCode(res.StatusCode, res);
    }

    [HttpPut]
    public IActionResult UpdateCourse(int id, UpdateCourseDto dto)
    {
        var res = service.UpdateCourses(id, dto);
        return StatusCode(res.StatusCode, res);
    }

    [HttpDelete]
    public IActionResult DeleteCourse(int id)
    {
        var res = service.DeleteCourses(id);
        return StatusCode(res.StatusCode, res);
    }


    [HttpGet("FilterByPrice")]
    public IActionResult GetCourseFilterByPrice(decimal price)
    {
        var res = service.GetCourseFilterByPrice(price);
        return StatusCode(res.StatusCode, res);
    }

    [HttpGet("With-Teachers")]
    public IActionResult GetCourseWithTeachers()
    {
        var res = service.GetCourseWithTeacher();
        return StatusCode(res.StatusCode, res);
    }
    
}