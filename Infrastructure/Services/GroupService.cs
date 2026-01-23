using System.Net;
using System.Text.RegularExpressions;
using Domain.Dto.Courses;
using Domain.Dto.Groups;
using Domain.Entities;
using Domain.Responses;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class GroupService(ApplicationDataContext context) : IGroupService
{
    public Response<List<GetGroupDto>> GetAllGroups()
    {
        
        var newGroups = context.Groups.Where(z => z.IsDeleted == false).Include(z => z.Course).ToList();
        var dto = newGroups.Select(z => new GetGroupDto()
        {
            Id = z.Id,
            Name = z.Name,
            IsStarted = z.IsStarted,
            StartDate = z.StartDate,
            EndDate = z.EndDate
        }).ToList();
        if(dto.Count >  0)
            return new Response<List<GetGroupDto>>(dto);
        else
        {
            return new Response<List<GetGroupDto>>(HttpStatusCode.NotFound, "Group not found");
        }
    }

    public Response<GetGroupDto> GetGroupById(int groupId)
    {
        var res = context.Groups.FirstOrDefault(z => z.Id == groupId &&  z.IsDeleted == false);
        if (res == null)
            return new Response<GetGroupDto>(HttpStatusCode.NotFound, " Group not found");
        var dto = new GetGroupDto()
        {
            Name = res.Name,
            IsStarted = res.IsStarted,
            StartDate = res.StartDate,
            EndDate = res.EndDate
        };
        return new Response<GetGroupDto>(dto);
    }

    public Response<List<GetGroupWithCourse>> GetGroupWithCourseByCourseId(int courseId)
    {
        var res = context.Groups.Where(x => x.IsDeleted == false && x.Id == courseId).Include(z => z.Course).ToList();
        var rew = res.Select(z=> new GetGroupWithCourse()
        {
            Name = z.Name,
            IsStarted = z.IsStarted,
            StartDate = z.StartDate,
            EndDate = z.EndDate,
            Course = new GetCourseDto()
            {
                Title = z.Course.Title,
                Description = z.Course.Description,
                Price = z.Course.Price,
                IsActive = z.Course.IsActive,
                CreatedAt = z.Course.CreatedAt
            }
        }).ToList();
        return new Response<List<GetGroupWithCourse>>(rew);



        

    }

    public Response<string> CreateGroup(CreateGroupDto dto)
    {
        try
        {
            var res = new Groups()
            {
                Name = dto.Name,
            };
            context.Groups.Add(res);
            var rew = context.SaveChanges();
            return rew >0
                ? new Response<string>(HttpStatusCode.Created, "Group created successfully")
                : new Response<string>(HttpStatusCode.BadRequest, "Group creation failed");
        }
        catch 
        {
            return new Response<string>(HttpStatusCode.InternalServerError, "internal server error");
        }
    }

    public Response<string> UpdateGroup(int groupId, UpdateGroupDto dto)
    {
        try
        {
             var res = context.Groups.FirstOrDefault(z => z.Id == groupId && z.IsDeleted == false);
             if (res == null)
                 return new Response<string>(HttpStatusCode.NotFound, " Group not found");
             res.Name = dto.Name;
             var rew = context.SaveChanges();
             return rew > 0
                 ? new Response<string>(HttpStatusCode.OK, "Group updated successfully")
                 : new Response<string>(HttpStatusCode.BadRequest, " Group not found");
        }
        catch  
        {
            return new Response<string>(HttpStatusCode.InternalServerError, "internal server error");
        }
    }

    public Response<string> DeleteGroup(int groupId)
    {
        try
        {
           var res = context.Groups.FirstOrDefault(z => z.Id == groupId && z.IsDeleted == false);
           res.IsDeleted = true;
           res.DeletedAt = DateTime.UtcNow;
           if (res == null)
               return new Response<string>(HttpStatusCode.NotFound, " Group not found");
           var rew = context.SaveChanges();
           return rew > 0
                 ? new Response<string>(HttpStatusCode.OK, "Group deleted successfully")
                 : new Response<string>(HttpStatusCode.BadRequest, " Group not found");
        }
        catch  
        {
            return new Response<string>(HttpStatusCode.InternalServerError, "internal server error");
        }
    }

    public Response<string> UpdateGroupByIdWithStart(int gId, UpdateGroupDto dtoS)
    {
        try
        {
            var res = context.Groups.FirstOrDefault(x => x.Id == gId && x.IsDeleted == false && x.IsStarted == true);
            if (res == null)
                return new Response<string>(HttpStatusCode.NotFound, " Group not found");
            res.Name = dtoS.Name;
            var rew = context.SaveChanges();
            return rew > 0
                ? new Response<string>(HttpStatusCode.OK, "Group updated successfully")
                : new Response<string>(HttpStatusCode.BadRequest, " Group not found");
        }
        catch 
        {
            return new Response<string>(HttpStatusCode.InternalServerError, "internal server error");
        }
    }

 
}