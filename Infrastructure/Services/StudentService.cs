using System.Net;
using System.Reflection.Metadata.Ecma335;
using Domain.Dto.Student;
using Domain.Entities;
using Domain.Responses;
using Infrastructure.Data;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class StudentService(ApplicationDataContext context) : IStudentService
{
    public Response<string> CreateStudent(CreateStudentDto dto)
    {
        try
        {
            var res = new Student()
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Phone = dto.Phone,
            };
            context.Students.Add(res);
            var rew = context.SaveChanges();
            return rew > 0
                ? new Response<string>(HttpStatusCode.Created, "Student created successfully")
                : new Response<string>(HttpStatusCode.BadRequest, "Student created failed");
        }
        catch 
        {
           return new Response<string>(HttpStatusCode.InternalServerError, "Internal Server Error");
        }
    }

    public Response<string> UpdateStudent(int id, UpdateStudentDto dto)
    {
        try
        {
            var res = context.Students.FirstOrDefault(s => s.Id == id);
            if(res == null)
                return new Response<string>(HttpStatusCode.NotFound, "Student not found");
            res.FirstName = dto.FirstName ?? res.FirstName;
            res.LastName = dto.LastName ?? res.LastName;
            res.Phone = dto.Phone ?? res.Phone;
            res.Email = dto.Email ?? res.Email;
            res.BirthDate = dto.BirthDate ?? res.BirthDate;
            var rew = context.SaveChanges();
            return rew > 0
                ? new Response<string>(HttpStatusCode.OK,  "Student updated successfully")
                : new Response<string>(HttpStatusCode.NotFound, "Student not found");

        }
        catch 
        {
                return new Response<string>(HttpStatusCode.InternalServerError, "Internal Server Error");
        }
        
    }

    public Response<string> DeleteStudent(int id)
    {
        var res = context.Students.FirstOrDefault(x => x.IsDeleted == false);
        res.IsDeleted = true;
        res.DeletedAt = DateTime.UtcNow;
        var rew = context.SaveChanges();
        return rew > 0
            ? new Response<string>(HttpStatusCode.OK,  "Student deleted successfully")
            : new Response<string>(HttpStatusCode.NotFound,  "Student not found");
    }

    public Response<List<GetStudentDto>> GetAllStudent()
    {
        var res = context.Students.Where(x => x.IsDeleted == false).ToList();
        var rew =res.Select(x=>  new GetStudentDto()
        {
            Id = x.Id,
            FirstName = x.FirstName,
            LastName = x.LastName,
            Email = x.Email,
            Phone = x.Phone,
            BirthDate = x.BirthDate,
        }).ToList();
        return new Response<List<GetStudentDto>>(rew);
    }

    public Response<GetStudentDto> GetStudentById(int id)
    { 
       var res = context.Students.FirstOrDefault(x => x.Id == id);
       if(res == null)
           return new Response<GetStudentDto>(HttpStatusCode.NotFound, "Student not found");
       var dto = new GetStudentDto()
       {
           FirstName = res.FirstName,
           LastName = res.LastName,
           Email = res.Email,
           Phone = res.Phone,
           BirthDate = res.BirthDate
       };
       return new Response<GetStudentDto>(dto);
    }

    public Response<List<GetStudentDto>> GetStudentByDelete()
    {
        var res = context.Students.Where(x => x.IsDeleted == true).ToList();
        var dto = res.Select(x => new GetStudentDto()
        {
            Id = x.Id,
            FirstName = x.FirstName,
            LastName = x.LastName,
            Email = x.Email,
            Phone = x.Phone,
            BirthDate = x.BirthDate,
        }).ToList();
        return new Response<List<GetStudentDto>>(dto);
    }

    public Response<string> RestoringDeletedFiles(int id)
    {
        try
        {
            
            var res = context.Students.FirstOrDefault(x => x.Id == id && x.IsDeleted == true);
            if (res == null)
                return new Response<string>(HttpStatusCode.NotFound, "Student not found");
            res.IsDeleted = false;
            res.DeletedAt = null;
            var ce = context.SaveChanges();
            return ce > 0
                ? new Response<string>(HttpStatusCode.OK, "Student updated successfully")
                : new Response<string>(HttpStatusCode.BadRequest, " Student not found");

        }
        catch  
        {
            return new Response<string>(HttpStatusCode.InternalServerError, "Internal Server Error");
        }
        
    }
}