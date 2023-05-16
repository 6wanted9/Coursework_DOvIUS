using System.Text;
using ConsoleTables;
using CourseworkTask.Enums;
using CourseworkTask.Interfaces;
using CourseworkTask.Models;

namespace CourseworkTask.Services;

internal class TaskConditionsForDisplayBuilder : ITaskConditionsForDisplayBuilder
{
    private const string Empty = "-";

    public string Build(TaskConditions task)
    {
        var builder = new StringBuilder();
        builder.AppendLine("Initial State:");
        builder.AppendLine(GenerateTable(task));

        return builder.ToString();
    }

    private string GenerateTable(TaskConditions task)
    {
        var table = new ConsoleTable(
            "Base / Subject",
            "Coordinates",
            "Weight").Configure(o => o.EnableCount = false);

        table.AddRow(BaseType.A, task.Bases[BaseType.A].Coordinates, Empty);
        table.AddRow(BaseType.B, task.Bases[BaseType.B].Coordinates, Empty);
        task.Subjects.ForEach(s => table.AddRow(s.PersonalNumber, s.Coordinates, s.Weight));

        return table.ToString();
    }
}