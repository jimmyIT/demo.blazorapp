
using Source.EF.Bases.Entities;

namespace Source.EF.Entities.Parameters;

public class ApplicationParameterEntity : IBaseEntityDetails
{
    public int Id {  get; set; }
    public string Code { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool Editable { get; set; }
    public byte[]? Timestamp { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime? AmendedOn { get; set; }
    public string CreateBy { get; set; } = string.Empty;
    public string AmendedBy { get; set; } = string.Empty;
}
