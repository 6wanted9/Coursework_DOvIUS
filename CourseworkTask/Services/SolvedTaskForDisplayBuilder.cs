using System.Text;
using ConsoleTables;
using CourseworkTask.Enums;
using CourseworkTask.Extensions;
using CourseworkTask.Interfaces;
using CourseworkTask.Models;

namespace CourseworkTask.Services;

internal class SolvedTaskForDisplayBuilder : ISolvedTaskForDisplayBuilder
{
    public string Build(SolvedTaskModel solvedTask)
    {
        var builder = new StringBuilder();
        builder.AppendLine("Solution.");
        builder.AppendLine(GenerateSolutionForBase(solvedTask, BaseType.A));
        builder.AppendLine(GenerateSolutionForBase(solvedTask, BaseType.B));
        builder.AppendLine($"Difference between Weighted Distances: {solvedTask.TargetFunctionValue.Format()}");

        return builder.ToString();
    }

    private string GenerateSolutionForBase(SolvedTaskModel solvedTask, BaseType baseType)
    {
        var builder = new StringBuilder();
        builder.AppendLine($"Base {baseType}:");
        builder.Append(GenerateTable(solvedTask, baseType));
        var sumOfWeightedDistances = solvedTask.BasesSubjectsWithWeightedDistances[baseType].Sum(s => s.Value);
        builder.AppendLine($"Sum of Weighted Distances: {sumOfWeightedDistances.Format()}");

        return builder.ToString();
    }
    private string GenerateTable(SolvedTaskModel solvedTask, BaseType baseType)
    {
        var table = new ConsoleTable(
            "Subject",
            "Coordinates",
            "Weight",
            "Weighted Distance").Configure(o => o.EnableCount = false);

        AddBaseSubjectsToTable(
            table,
            solvedTask.BasesSubjectsWithWeightedDistances[baseType]);

        return table.ToString();
    }

    private void AddBaseSubjectsToTable(ConsoleTable table, Dictionary<Subject, double> baseSubjects)
    {
        foreach (var item in baseSubjects)
        {
            table.AddRow(item.Key.PersonalNumber, item.Key.Coordinates, item.Key.Weight, item.Value.Format());
        }
    }
}