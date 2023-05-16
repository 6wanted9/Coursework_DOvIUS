namespace TaskRunner.Extensions;

internal static class EnumExtensions
{
    public static bool IsValid<TEnum>(string? key, out TEnum value)
        where TEnum : struct, Enum
    {
        if (string.IsNullOrEmpty(key) ||
            !Enum.TryParse(key, out value) ||
            !Enum.IsDefined(value))
        {
            value = default;

            return false;
        }

        return true;
    }
}