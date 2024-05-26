namespace Source.Server.Application.Handlers.Students.GetAll;

public class GetAllStudentsResponse
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public byte[]? Timestamp { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public byte[]? Photo { get; set; }
    public decimal Height { get; set; }
    public float Weight { get; set; }
    public DateTime CreatedOn { get; set; }
    public string? GradeCode { get; set; }
}
