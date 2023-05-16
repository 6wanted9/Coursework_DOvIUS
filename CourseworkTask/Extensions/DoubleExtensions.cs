namespace CourseworkTask.Extensions;

public static class DoubleExtensions
{
    private const string FloatingFormatTemplate = "{0:0.00}";

    public static string Format(this double number)
    {
        return string.Format(FloatingFormatTemplate, number);
    }
}