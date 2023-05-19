using System.Diagnostics;
using ConsoleTables;
using CourseworkTask.Extensions;
using CourseworkTask.Interfaces;
using CourseworkTask.Models;
using GreedyAlgorithm.Interfaces;
using LocalSearchAlgorithm.Interfaces;
using TaskRunner.Enums;
using TaskRunner.Extensions;
using TaskRunner.Interfaces.RunningActions.SpecificTaskRunners;
using TaskRunner.Models;

namespace TaskRunner.Services.RunningActions.SpecificTaskRunners;

public class EffectOfTaskSizeOnTimeTaskRunner : ISpecificTaskRunner
{
    private const string TimeExecutionTemplate = "{0} ms";
    private const int ExperimentsAmount = 20;
    private const int TaskSizesAmount = 10;
    private const int StepBetweenTaskSizes = 6;

    private readonly ITaskConditionsGenerator _taskConditionsGenerator;
    private readonly ILocalSearchTaskSolver _localSearchTaskSolver;
    private readonly IGreedyTaskSolver _greedyTaskSolver;

    public EffectOfTaskSizeOnTimeTaskRunner(
        ITaskConditionsGenerator taskConditionsGenerator,
        ILocalSearchTaskSolver localSearchTaskSolver,
        IGreedyTaskSolver greedyTaskSolver)
    {
        _taskConditionsGenerator = taskConditionsGenerator;
        _localSearchTaskSolver = localSearchTaskSolver;
        _greedyTaskSolver = greedyTaskSolver;
    }

    public void Run(TaskParameters parameters)
    {
        var taskSizes = Enumerable.Range(1, TaskSizesAmount).Select(order => order * StepBetweenTaskSizes).ToList();
        var table = CreateTable();
        foreach (var taskSize in taskSizes)
        {
            var tasks = _taskConditionsGenerator.Generate(
                ExperimentsAmount,
                taskSize,
                parameters.MaxSubjectWeight).ToList();

            var greedyAverageExecutionTime = GetAverageExecutionTimeOfAlgorithm(tasks, AlgorithmType.Greedy);
            var localSearchAverageExecutionTime = GetAverageExecutionTimeOfAlgorithm(tasks, AlgorithmType.LocalSearch);
            table.AddRow(taskSize, greedyAverageExecutionTime, localSearchAverageExecutionTime);
        }

        table.AddAverageValues(
            valueSelector: v => v.Split(' ')[0],
            valueFormatter: v => string.Format(TimeExecutionTemplate, v));

        Console.WriteLine(table);
    }

    private static ConsoleTable CreateTable()
    {
        var table = new ConsoleTable(
            "Task Size",
            "Greedy Average Time",
            "Local Search Average Time").Configure(o => o.EnableCount = false);

        return table;
    }

    private string GetAverageExecutionTimeOfAlgorithm(
        IEnumerable<TaskConditions> tasks,
        AlgorithmType algorithmType)
    {
        Func<TaskConditions, SolvedTaskModel> solver = algorithmType switch
        {
            AlgorithmType.Greedy => conditions => _greedyTaskSolver.Solve(conditions),
            AlgorithmType.LocalSearch => conditions => _localSearchTaskSolver.Solve(conditions),
            _ => throw new ArgumentOutOfRangeException(nameof(algorithmType))
        };

        var stopWatch = new Stopwatch();
        stopWatch.Start();
        foreach (var task in tasks)
        {
            solver(task);
        }

        stopWatch.Stop();

        return string.Format(TimeExecutionTemplate, (stopWatch.Elapsed.TotalMilliseconds / tasks.Count()).Format());
    }
}