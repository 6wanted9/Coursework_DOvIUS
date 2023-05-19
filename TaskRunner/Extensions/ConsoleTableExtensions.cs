using ConsoleTables;
using CourseworkTask.Extensions;

namespace TaskRunner.Extensions;

public static class ConsoleTableExtensions
{
    public static void AddAverageValues(
        this ConsoleTable table,
        Func<string, string>? valueSelector = null,
        Func<string, string>? valueFormatter = null)
    {
        var averages = table.Rows
            .SelectMany(r => r.Skip(1).Select((value, index) => new {Index = index, Value = value}))
            .GroupBy(r => r.Index)
            .Select(g => g.Average(s => ParseValue(s.Value, valueSelector)).FormatValue(valueFormatter))
            .ToArray();

        table.AddRow(averages.Prepend("Average").ToArray());
    }

    private static double ParseValue(object value, Func<string, string>? valueSelector)
    {
        var stringValue = value.ToString();

        return double.Parse(valueSelector?.Invoke(stringValue) ?? stringValue);
    }

    private static string FormatValue(this double value, Func<string, string>? valueFormatter)
    {
        var formattedNumber = value.Format();

        return valueFormatter?.Invoke(formattedNumber) ?? formattedNumber;
    }
}