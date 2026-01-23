using System.ComponentModel.DataAnnotations;

namespace Domain.Dto.Groups;

public class GetGroupDto
{
    public int Id { get; set; } 
   public required string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsStarted { get; set; }
    
}