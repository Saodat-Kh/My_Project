using System.Text.RegularExpressions;
using Domain.Enum;

namespace Domain.Entities;

public class StudentGroups : BaseEntities
{
        public int StudentId { get; set; }
        public int GroupId { get; set; }
        public DateTime EnrolledAt {get; set;} = DateTime.UtcNow;
        public int? Grade { get; set; }
        public ActiveStatus? Status { get; set; }
        
        
        public Student? Student { get; set; }
        public Group? Group { get; set; }
}