namespace Source.Server.Application.Handlers.Students.Create;

public class CreateStudentRequest
{
    public string Name { get; set; } = string.Empty;
    public DateTime? DateOfBirth { get; set; }
    public byte[]? Photo { get; set; }
    public decimal Height { get; set; }
    public float Weight { get; set; }
    public string? GradeCode { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
