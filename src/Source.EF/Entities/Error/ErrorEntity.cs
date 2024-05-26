using Source.EF.Bases.Entities;

namespace Source.EF.Entities.Error;

public class ErrorEntity : IBaseEntity
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string ErrorMessage { get; set; } = string.Empty;
    public string ResourceKey { get; set; } = string.Empty;
    public byte[]? Timestamp { get; set; }
}
