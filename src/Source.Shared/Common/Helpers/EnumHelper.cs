namespace Source.Shared.Common.Helpers;

public static class EnumHelper
{
    public static IEnumerable<string> GetEnumValues<TEnum>()
    {
        Type type = Nullable.GetUnderlyingType(typeof(TEnum)) ?? typeof(TEnum);

        if (!type.IsEnum)
        {
            throw new ArgumentException("TEnum must be Enum type");
        }

        var validValues = new List<string>();
        foreach (TEnum e in Enum.GetValues(type))
        {
            validValues.Add(e.ToString());
        }

        return validValues;
    }

    public static Enum ConvertStringToEnum<TEnum>(string? value)
            where TEnum : struct, Enum
    {
        if (Enum.TryParse(value, out TEnum result))
        {
            return result;
        }

        throw new Exception($"Failed to Convert String {value} To Enum {typeof(TEnum)}");
    }
}
