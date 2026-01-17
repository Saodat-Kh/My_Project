namespace Domain.Entities;

public class BaseEntities
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    
 
}