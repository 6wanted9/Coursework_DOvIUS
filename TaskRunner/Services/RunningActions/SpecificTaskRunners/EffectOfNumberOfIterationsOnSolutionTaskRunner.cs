using ConsoleTables;
using CourseworkTask.Extensions;
using CourseworkTask.Interfaces;
using LocalSearchAlgorithm.Interfaces;
using TaskRunner.Extensions;
using TaskRunner.Interfaces.RunningActions.SpecificTaskRunners;
using TaskRunner.Models;

namespace TaskRunner.Services.RunningActions.SpecificTaskRunners;

public class EffectOfNumberOfIterationsOnSolutionTaskRunner : ISpecificTaskRunner
{
    private const int ExperimentsAmount = 20;
    private const int NumberOfPowers = 3;

    private readonly ITaskConditionsGenerator _taskConditionsGenerator;
    private readonly ILocalSearchTaskSolver _localSearchTaskSolver;

    public EffectOfNumberOfIterationsOnSolutionTaskRunner(
        ITaskConditionsGenerator taskConditionsGenerator,
        ILocalSearchTaskSolver localSearchTaskSolver)
    {
        _taskConditionsGenerator = taskConditionsGenerator;
        _localSearchTaskSolver = localSearchTaskSolver;
    }

    public void Run(TaskParameters parameters)
    {
        var tasks = _taskConditionsGenerator.Generate(
            ExperimentsAmount,
            parameters.SubjectsAmount,
            parameters.MaxSubjectWeight);

        var subjectsAmount = tasks.First().Subjects.Count;
        var powers = Enumerable.Range(1, NumberOfPowers).ToList();
        var table = CreateTable(powers);
        for (int i = 0; i < tasks.Count; i++)
        {
            var rowValues = powers.Select(power => _localSearchTaskSolver.Solve(
                tasks[i],
                (int) Math.Pow(subjectsAmount, power)).TargetFunctionValue.Format()).ToList();

            rowValues.Insert(0, (i + 1).ToString());
            table.AddRow(rowValues.ToArray());
        }

        table.AddAverageValues();
        Console.WriteLine(table);
    }

    private static ConsoleTable CreateTable(List<int> powers)
    {
        var table = new ConsoleTable("Iteration").Configure(o => o.EnableCount = false);
        table.AddColumn(powers.Select(power => $"Target Value with n^{power} iterations"));

        return table;
    }
}