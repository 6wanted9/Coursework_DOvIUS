using ConsoleTables;
using CourseworkTask.Extensions;
using CourseworkTask.Interfaces;
using CourseworkTask.Models;
using GreedyAlgorithm.Interfaces;
using LocalSearchAlgorithm.Interfaces;
using TaskRunner.Enums;
using TaskRunner.Interfaces.RunningActions.SpecificTaskRunners;
using TaskRunner.Models;

namespace TaskRunner.Services.RunningActions.SpecificTaskRunners;

public class EffectOfTaskSizeOnSolutionTaskRunner : ISpecificTaskRunner
{
    private const int ExperimentsAmount = 20;
    private const int TaskSizesAmount = 10;
    private const int StepBetweenTaskSizes = 6;

    private readonly ITaskConditionsGenerator _taskConditionsGenerator;
    private readonly ILocalSearchTaskSolver _localSearchTaskSolver;
    private readonly IGreedyTaskSolver _greedyTaskSolver;

    public EffectOfTaskSizeOnSolutionTaskRunner(
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

            var greedyAverageTargetFunctionValue = GetAverageTargetFunctionValue(tasks, AlgorithmType.Greedy);
            var localSearchAverageTargetFunctionValue = GetAverageTargetFunctionValue(tasks, AlgorithmType.LocalSearch);
            table.AddRow(taskSize, greedyAverageTargetFunctionValue, localSearchAverageTargetFunctionValue);
        }

        Console.WriteLine(table);
    }

    private static ConsoleTable CreateTable()
    {
        var table = new ConsoleTable(
            "Task Size",
            "Greedy Average Target Function Value",
            "Local Search Average Target Function Value").Configure(o => o.EnableCount = false);

        return table;
    }

    private string GetAverageTargetFunctionValue(
        IEnumerable<TaskConditions> tasks,
        AlgorithmType algorithmType)
    {
        Func<TaskConditions, SolvedTaskModel> solver = algorithmType switch
        {
            AlgorithmType.Greedy => conditions => _greedyTaskSolver.Solve(conditions),
            AlgorithmType.LocalSearch => conditions => _localSearchTaskSolver.Solve(conditions),
            _ => throw new ArgumentOutOfRangeException(nameof(algorithmType))
        };

        return (tasks.Sum(t => solver(t).TargetFunctionValue) / tasks.Count()).Format();
    }
}