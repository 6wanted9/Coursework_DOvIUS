using CourseworkTask.Enums;
using CourseworkTask.Interfaces;
using CourseworkTask.Models;
using GreedyAlgorithm.Interfaces;

namespace GreedyAlgorithm.Services;

internal class GreedyTaskSolver : IGreedyTaskSolver
{
    private readonly IWeightedDistanceToBaseCalculationService _weightedDistanceToBaseCalculationService;

    public GreedyTaskSolver(IWeightedDistanceToBaseCalculationService weightedDistanceToBaseCalculationService)
    {
        _weightedDistanceToBaseCalculationService = weightedDistanceToBaseCalculationService;
    }

    public SolvedTaskModel Solve(TaskConditions task, bool ascendingInitialOrder = false)
    {
        var sortedSubjects = task.Subjects.OrderByDescending(s => s.Weight).ToList();
        if (ascendingInitialOrder)
        {
            sortedSubjects.Reverse();
        }

        var sumOfWeightedDistancesToBaseA = 0.0;
        var baseASubjectsWithWeightedDistances = new Dictionary<Subject, double>();

        var sumOfWeightedDistancesToBaseB = 0.0;
        var baseBSubjectsWithWeightedDistances = new Dictionary<Subject, double>();

        foreach (var subject in sortedSubjects)
        {
            var weightedDistanceToA = _weightedDistanceToBaseCalculationService.Calculate(subject, task.Bases[BaseType.A]);
            var weightedDistanceToB = _weightedDistanceToBaseCalculationService.Calculate(subject, task.Bases[BaseType.B]);
            if (weightedDistanceToA + sumOfWeightedDistancesToBaseA <= weightedDistanceToB + sumOfWeightedDistancesToBaseB)
            {
                AddSubjectToBase(
                    baseASubjectsWithWeightedDistances,
                    subject,
                    weightedDistanceToA,
                    ref sumOfWeightedDistancesToBaseA);
            }
            else
            {
                AddSubjectToBase(
                    baseBSubjectsWithWeightedDistances,
                    subject,
                    weightedDistanceToB,
                    ref sumOfWeightedDistancesToBaseB);
            }
        }

        return new SolvedTaskModel(baseASubjectsWithWeightedDistances, baseBSubjectsWithWeightedDistances);
    }

    private void AddSubjectToBase(
        Dictionary<Subject, double> baseSubjectsWithWeightedDistances,
        Subject subject,
        double weightedDistanceToBase,
        ref double sumOfWeightedDistances)
    {
        baseSubjectsWithWeightedDistances.Add(subject, weightedDistanceToBase);
        sumOfWeightedDistances += weightedDistanceToBase;
    }
}