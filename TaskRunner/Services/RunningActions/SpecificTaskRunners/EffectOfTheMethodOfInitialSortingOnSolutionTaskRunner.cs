using ConsoleTables;
using CourseworkTask.Extensions;
using CourseworkTask.Interfaces;
using GreedyAlgorithm.Interfaces;
using TaskRunner.Extensions;
using TaskRunner.Interfaces.RunningActions.SpecificTaskRunners;
using TaskRunner.Models;

namespace TaskRunner.Services.RunningActions.SpecificTaskRunners;

public class EffectOfTheMethodOfInitialSortingOnSolutionTaskRunner : ISpecificTaskRunner
{
    private const int ExperimentsAmount = 20;

    private readonly ITaskConditionsGenerator _taskConditionsGenerator;
    private readonly IGreedyTaskSolver _greedyTaskSolver;

    public EffectOfTheMethodOfInitialSortingOnSolutionTaskRunner(
        ITaskConditionsGenerator taskConditionsGenerator,
        IGreedyTaskSolver greedyTaskSolver)
    {
        _taskConditionsGenerator = taskConditionsGenerator;
        _greedyTaskSolver = greedyTaskSolver;
    }

    public void Run(TaskParameters parameters)
    {
        var tasks = _taskConditionsGenerator.Generate(
            ExperimentsAmount,
            parameters.SubjectsAmount,
            parameters.MaxSubjectWeight);

        var table = CreateTable();
        for (int i = 0; i < tasks.Count; i++)
        {
            var targetFunctionValueWithAscendingSorting = _greedyTaskSolver.Solve(tasks[i], true).TargetFunctionValue;
            var targetFunctionValueWithDescendingSorting = _greedyTaskSolver.Solve(tasks[i]).TargetFunctionValue;
            table.AddRow(
                i + 1,
                targetFunctionValueWithAscendingSorting.Format(),
                targetFunctionValueWithDescendingSorting.Format());
        }

        table.AddAverageValues();
        Console.WriteLine(table);
    }

    private static ConsoleTable CreateTable()
    {
        return new ConsoleTable(
            "Iteration",
            "Ascending Target Value",
            "Descending Target Value").Configure(o => o.EnableCount = false);
    }
}