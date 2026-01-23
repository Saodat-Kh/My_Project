using System.Net;
using Domain.Dto.Student;
using Domain.Dto.StudentGroups;
using Domain.Entities;
using Domain.Enum;
using Domain.Responses;
using Infrastructure.Data;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class StudentGroupService(ApplicationDataContext context) : IStudentGroupService
{
    public Response<string> CreateStudent(CreateStudentGroupDto dto)
    {
        try
        {
            var res = new StudentGroups()
            {
                StudentId = dto.StudentId,
                GroupId = dto.GroupId,
                EnrolledAt = DateTime.UtcNow,
                CreatedAt = DateTime.UtcNow,
                Status = ActiveStatus.Active
            };
            context.StudentGroups.Add(res);
            var rew = context.SaveChanges();
            return rew == null
                ?   new Response<string>(HttpStatusCode.Created, "Student group created successfully")
                :   new Response<string>(HttpStatusCode.BadRequest, "Student Group Bad");

        }
        catch 
        {
            return new Response<string>(HttpStatusCode.InternalServerError, "internal server error");
        }   
    }

    public Response<string> DeleteStudent(string studentId)
    {
        throw new NotImplementedException();
    }

    public Response<List<GetStudentDto>> GetAllStudents()
    {
        throw new NotImplementedException();
    }

    public Response<string> GiveAGradeToTheStudent(ActiveStatus status)
    {
        throw new NotImplementedException();
    }

    public Response<string> CreateStudentGroup(CreateStudentGroupDto dto)
    {
        throw new NotImplementedException();
    }

    public Response<string> DeleteStudentGroup(string groupId)
    {
        throw new NotImplementedException();
    }

    public Response<string> GiveAGradeToTheStudent(GetStudentGroupDto dto)
    {
        throw new NotImplementedException();
    }

    public Response<List<GetStudentGroupDto>> GetAllStudentGroups()
    {
        throw new NotImplementedException();
    }
}