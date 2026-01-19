using System.Net;
using Domain.Dto.Courses;
using Domain.Dto.Teachers;
using Domain.Entities;
using Domain.Responses;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class CourseService(ApplicationDataContext context) : ICourseService
{
    public Response<string> CreateCourses(CreateCourseDto dto)
    {
        var newCourse = new Courses()
        {
            Title = dto.Title,
            Description = dto.Description,
            Price = dto.Price,
        };
        context.Courses.Add(newCourse);
        var res = context.SaveChanges();
        return res > 0
            ? new Response<string>(HttpStatusCode.Created, "Course created successfully")
            : new Response<string>(HttpStatusCode.BadRequest, "Course creation failed");
    }

    public Response<string> UpdateCourses(int id, UpdateCourseDto dto)
    {
        var res = context.Courses.FirstOrDefault(x=>x.Id == id && x.IsDeleted == false);
        if (res == null)
            return new Response<string>(HttpStatusCode.NotFound, "Course not found");
        res.Title = dto.Title ?? res.Title;
        res.Description = dto.Description ?? res.Description ;
        res.Price = dto.Price ?? res.Price ;
        var rew = context.SaveChanges();
        return rew > 0
            ? new Response<string>(HttpStatusCode.OK,  "Course updated successfully")
            :  new Response<string>(HttpStatusCode.BadRequest, "Course updation failed");
    }

    public Response<string> DeleteCourses(int id)
    {
        var res = context.Courses.FirstOrDefault(x => x.Id == id && x.IsDeleted == false);
        res.IsDeleted = true;
        res.DeletedAt = DateTime.UtcNow;
        if(res == null)
            return new Response<string>(HttpStatusCode.NotFound, "Course not found");
        var res2 = context.SaveChanges();
        return res2 > 0
            ? new Response<string>(HttpStatusCode.OK, "Course deleted successfully")
            : new Response<string>(HttpStatusCode.BadRequest, "Course deletion failed");
    }

    public Response<List<GetCourseDto>> GetAllCourses()
    {
        var res = context.Courses.Where(x=>x.IsDeleted == false).ToList();
        var dto = res.Select(z => new GetCourseDto()
        {
            Id = z.Id,
            Title = z.Title,
            Description = z.Description,
            Price = z.Price,
            CreatedAt = z.CreatedAt,
            IsActive = z.IsActive
        }).ToList();
        if (dto.Count > 0)
            return new Response<List<GetCourseDto>>(dto);
        else
        {
            return new Response<List<GetCourseDto>>(HttpStatusCode.NotFound, "Course not found");
        }
    }

    public Response<GetCourseDto> GetCourseById(int id)
    {
        var res = context.Courses.FirstOrDefault(x=> x.Id == id && x.IsDeleted == false);
        var dto = new GetCourseDto()
        {
            Title = res.Title,
            Description = res.Description,
            Price = res.Price
        };
        return new Response<GetCourseDto>(dto);
    }

    public Response<GetCourseDto> GetCourseFilterByPrice(decimal price)
    {
        var res = context.Courses.FirstOrDefault(x => x.Price == price && x.IsDeleted == false);
        if (res == null)
            return new Response<GetCourseDto>(HttpStatusCode.NotFound, "Course not found");
        var dto = new GetCourseDto()
        {
            Title = res.Title,
            Description = res.Description,
            Price = res.Price,
            IsActive = res.IsActive,
            CreatedAt = res.CreatedAt
        };
        return new Response<GetCourseDto>(dto);
    }

    public Response<List<GetCourseWithTeacher>> GetCourseWithTeacher()
    {
       var res = context.Courses.Where(x => x.IsDeleted == false).Include(z => z.Teacher ).ToList();
         var rew = res.Select(z => new GetCourseWithTeacher()
         {
             Title = z.Title,
             Description = z.Description,
             Price = z.Price,
             IsActive = z.IsActive,
             Teacher   = new  GetTeacherDto()
             {
                 Id = z.Teacher!.Id,
                 FirstName = z.Teacher.FirstName,
                 LastName = z.Teacher.LastName,
                 Email = z.Teacher.Email,
                 Phone = z.Teacher.Phone,
                 Specialization = z.Teacher.Specialization,
                 ExperienceYears = z.Teacher.ExperienceYears,
                 CreatedAt = z.CreatedAt
             }
         }).ToList();
        return new Response<List<GetCourseWithTeacher>>(rew);
    }
}