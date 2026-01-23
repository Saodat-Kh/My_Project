namespace Domain.Dto.Student;

public class GetStudentDto
{
    public int  Id { get; set; }
    public required string FirstName { get; set; } = string.Empty;
    public string LastName  { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
    public string Email  { get; set; } = string.Empty;
    public string Phone { get; set; }

}