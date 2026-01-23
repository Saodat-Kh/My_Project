using System.Net;
using Domain.Dto.Courses;
using Domain.Dto.Teachers;
using Domain.Entities;
using Domain.Responses;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class TeacherService(ApplicationDataContext context) : ITeacherService
{
    public Response<string> CreateTeacher(CreateTeacherDto dto)
    {

        var newTeacher = new Teachers()
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            Phone = dto.Phone,
            ExperienceYears = dto.ExperienceYears,
            Specialization = dto.Specialization
        };
        context.Teachers.Add(newTeacher);
        var res = context.SaveChanges();
        return res > 0
            ? new Response<string>(HttpStatusCode.Created, "Teacher created successfully")
            : new Response<string>(HttpStatusCode.BadRequest, "Teacher creation failed");
    }

    public Response<string> UpdateTeacher(int id, UpdateTeacherDto dto)
    {
        var res = context.Teachers.FirstOrDefault(t => t.Id == id);
        if (res == null)
            return new Response<string>(HttpStatusCode.NotFound, "Teacher not found");
        res.FirstName = dto.FirstName!;
        res.LastName = dto.LastName!;
        res.Email = dto.Email!;
        res.Phone = dto.Phone!;
        res.Specialization = dto.Specialization!;
        res.ExperienceYears = dto.ExperienceYears ?? res.ExperienceYears;
        var rew = context.SaveChanges();
        return rew > 0
            ? new Response<string>(HttpStatusCode.OK, "Teacher updated successfully")
            : new Response<string>(HttpStatusCode.BadRequest, "Teacher updation failed");
    }

    public Response<string> DeleteTeacher(int id)
    {
        var res = context.Teachers.FirstOrDefault(t => t.Id == id && t.IsDeleted == false);
        if(res == null)
            return new Response<string>(HttpStatusCode.NotFound, "Teacher not  found");
        res.IsDeleted = true;
        res.DeletedAt = DateTime.UtcNow;
        var rew = context.SaveChanges();
        return rew > 0
            ? new Response<string>(HttpStatusCode.OK, "Teacher deleted successfully")
            : new Response<string>(HttpStatusCode.BadRequest, "Teacher deletion failed");
    }
    

    public Response<List<GetTeacherDto>> GetAllTeachers()
    {
        var res = context.Teachers.Where(x=>x.IsDeleted == false).ToList();
        var dto = res.Select(z => new GetTeacherDto()
        {
             Id = z.Id,
            FirstName = z.FirstName,
            LastName = z.LastName,
            Email = z.Email,
            Phone = z.Phone,
            Specialization = z.Specialization,
            ExperienceYears = z.ExperienceYears,
            CreatedAt = z.CreatedAt
        }).ToList();
        if (dto.Count > 0)
            return new Response<List<GetTeacherDto>>(dto);
        else
        {
            return new Response<List<GetTeacherDto>>(HttpStatusCode.NotFound, "Teacher not found");
        }
    }

    public Response<GetTeacherDto> GetTeacherById(int id)
    {
        var res = context.Teachers.FirstOrDefault(t => t.Id == id && t.IsDeleted == false);
        if (res == null)
            return new Response<GetTeacherDto>(HttpStatusCode.NotFound, "Teacher not found");
        var dto = new GetTeacherDto()
        {
            FirstName = res.FirstName,
            LastName = res.LastName,
            Email = res.Email,
            Phone = res.Phone,
            Specialization = res.Specialization,
            ExperienceYears = res.ExperienceYears
        };
        return new Response<GetTeacherDto>(dto);
    }

    public Response<List<GetTeacherWithCourse>> GetAllTeachersWithCoursesIsActive()
    {
        var res = context.Teachers.Where(x => x.IsDeleted ).Include(z=>z.Courses).ToList();
        var rew = res.Select(z => new GetTeacherWithCourse()
        {
            FirstName = z.FirstName,
            LastName = z.LastName,
            Email = z.Email,
            Phone = z.Phone,
            ExperienceYears = z.ExperienceYears,
            Specialization = z.Specialization,
            Courses = z.Courses.Where(x=>x.IsActive).Select(c => new GetCourseDto()
            {
                Title = c.Title,
                Id = c.Id,
                Description = c.Description,
                CreatedAt = c.CreatedAt
            }).ToList()
        }).ToList();
        return new Response<List<GetTeacherWithCourse>>(rew);

    }

    public Response<GetTeacherDto> GetTeacherSearchByName(string name)
    {
        var res = context.Teachers.FirstOrDefault(x => x.FirstName == name && x.IsDeleted == false);
        if (res == null)
            return new Response<GetTeacherDto>(HttpStatusCode.NotFound, "Такого имени нет!");
        var dto = new GetTeacherDto()
        {
            FirstName = res.FirstName,
            LastName = res.LastName,
            Email = res.Email,
            Phone = res.Phone,
            Specialization = res.Specialization,
            ExperienceYears = res.ExperienceYears,
        };
        return new Response<GetTeacherDto>(dto);
    }
}