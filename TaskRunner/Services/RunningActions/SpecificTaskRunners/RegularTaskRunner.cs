using CourseworkTask.Interfaces;
using CourseworkTask.Models;
using GreedyAlgorithm.Interfaces;
using LocalSearchAlgorithm.Interfaces;
using TaskRunner.Enums;
using TaskRunner.Interfaces.RunningActions.SpecificTaskRunners;
using TaskRunner.Models;

namespace TaskRunner.Services.RunningActions.SpecificTaskRunners;

internal class RegularTaskRunner : ISpecificTaskRunner
{
    private readonly ITaskConditionsGenerator _taskConditionsGenerator;
    private readonly ITaskConditionsForDisplayBuilder _taskConditionsForDisplayBuilder;
    private readonly ISolvedTaskForDisplayBuilder _solvedTaskForDisplayBuilder;
    private readonly IGreedyTaskSolver _greedyTaskSolver;
    private readonly ILocalSearchTaskSolver _localSearchTaskSolver;

    public RegularTaskRunner(
        ITaskConditionsGenerator taskConditionsGenerator,
        ITaskConditionsForDisplayBuilder taskConditionsForDisplayBuilder,
        ISolvedTaskForDisplayBuilder solvedTaskForDisplayBuilder,
        IGreedyTaskSolver greedyTaskSolver,
        ILocalSearchTaskSolver localSearchTaskSolver)
    {
        _taskConditionsGenerator = taskConditionsGenerator;
        _taskConditionsForDisplayBuilder = taskConditionsForDisplayBuilder;
        _solvedTaskForDisplayBuilder = solvedTaskForDisplayBuilder;
        _greedyTaskSolver = greedyTaskSolver;
        _localSearchTaskSolver = localSearchTaskSolver;
    }

    public void Run(TaskParameters parameters)
    {
        var task = _taskConditionsGenerator.Generate(parameters.SubjectsAmount, parameters.MaxSubjectWeight);
        Console.Write(_taskConditionsForDisplayBuilder.Build(task));

        SolveWithSpecificAlgorithm(task, AlgorithmType.Greedy);
        SolveWithSpecificAlgorithm(task, AlgorithmType.LocalSearch);
    }

    private void SolveWithSpecificAlgorithm(
        TaskConditions task,
        AlgorithmType algorithmType)
    {
        Console.WriteLine("==========================================================");
        Console.WriteLine($"{algorithmType} Algorithm:");
        var result = algorithmType switch
        {
            AlgorithmType.Greedy => _greedyTaskSolver.Solve(task),
            AlgorithmType.LocalSearch => _localSearchTaskSolver.Solve(task),
            _ => throw new ArgumentOutOfRangeException(nameof(algorithmType))
        };
        Console.Write(_solvedTaskForDisplayBuilder.Build(result));
    }
}