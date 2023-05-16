using System.Text;
using CourseworkTask.Models;

namespace CourseworkTask.Utils;

internal static class SubjectUtils
{
    public static string BuildForDisplay(this Dictionary<Subject, int> subjectsWithWeighedDistances)
    {
        var builder = new StringBuilder();
        builder.AppendLine("Subjects:");
        foreach (var subjectWithWeightedDistance in subjectsWithWeighedDistances)
        {
            builder.Append(subjectWithWeightedDistance.Key.BuildForDisplay());
            builder.Append($" | Weighted distance: {subjectWithWeightedDistance.Value}");
            builder.AppendLine();
        }

        builder.Append($"Sum of weighted distances: {subjectsWithWeighedDistances.Sum(swwd => swwd.Value)}");

        return builder.ToString();
    }

    private static string BuildForDisplay(this Subject subject)
    {
        var builder = new StringBuilder();
        builder.Append($"Number: {subject.PersonalNumber} | ");
        builder.Append($"Coordinates: {subject.Coordinates} | ");
        builder.Append($"Weight: {subject.Weight}");

        return builder.ToString();
    }
}