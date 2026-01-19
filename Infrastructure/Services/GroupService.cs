using System.Net;
using System.Text.RegularExpressions;
using Domain.Dto.Courses;
using Domain.Dto.Groups;
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

    public Response<GetGroupWithCourse> GetGroupWithCourseByCourseId(int courseId)
    {throw new NotImplementedException();
        // var res = context.Groups.FirstOrDefault(x => x.Id == courseId && x.IsDeleted == false);
        // if(res == null)
        //    return  new Response<GetGroupWithCourse>(HttpStatusCode.NotFound, " Group not found");
        // var dto = new GetGroupWithCourse()
        // {
        //     Name = res.Name,
        //     IsStarted = res.IsStarted,
        //     StartDate = res.StartDate,
        //     EndDate = res.EndDate,
        //     Course = res.Course.Select(c => new GetCourseDto()
        //     {
        //         Title = res.Course.Title,
        //         Description = res.Course.Description,
        //         Price = res.Course.Price,
        //         IsActive = res.Course.IsActive,
        //         CreatedAt = res.CreatedAt
        //     })
        // };
         
    }

    public Response<string> CreateGroup(CreateGroupDto dto)
    {throw new NotImplementedException();
         // var res = new Group()
         // {
         //     
         // }
    }

    public Response<string> UpdateGroup(int groupId, UpdateGroupDto dto)
    {
        throw new NotImplementedException();
    }

    public Response<string> DeleteGroup(int groupId)
    {
        throw new NotImplementedException();
    }

    public Response<string> UpdateCourseByIdWithStart(int gId, UpdateCourseDto dto)
    {
        throw new NotImplementedException();
    }
}