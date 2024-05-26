namespace Source.EF.Bases.Entities;

public interface IBaseEntity
{
    int Id { get; set; }
    string Code { get; set; }
    byte[]? Timestamp { get; set; }
}
