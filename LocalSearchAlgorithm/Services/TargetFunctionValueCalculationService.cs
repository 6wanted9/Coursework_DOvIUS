using CourseworkTask.Enums;
using CourseworkTask.Interfaces;
using CourseworkTask.Models;
using LocalSearchAlgorithm.Interfaces;
using LocalSearchAlgorithm.Models;

namespace LocalSearchAlgorithm.Services;

internal class TargetFunctionValueCalculationService : ITargetFunctionValueCalculationService
{
    private readonly IWeightedDistanceToBaseCalculationService _weightedDistanceToBaseCalculationService;

    public TargetFunctionValueCalculationService(
        IWeightedDistanceToBaseCalculationService weightedDistanceToBaseCalculationService)
    {
        _weightedDistanceToBaseCalculationService = weightedDistanceToBaseCalculationService;
    }

    public double Calculate(SubjectDistributionModel[] distributions, TaskConditions task)
    {
        var baseASumOfWeightedDistances = GetSumOfWeightedDistancesForBase(distributions, task.Bases, BaseType.A);
        var baseBSumOfWeightedDistances = GetSumOfWeightedDistancesForBase(distributions, task.Bases, BaseType.B);

        return Math.Abs(baseASumOfWeightedDistances - baseBSumOfWeightedDistances);
    }

    private double GetSumOfWeightedDistancesForBase(
        SubjectDistributionModel[] distributions,
        Bases bases,
        BaseType baseType)
    {
        return distributions
            .Where(d => d.BaseAssignment == baseType)
            .Sum(d => GetOrCalculateNewWeightedDistance(baseType, d, bases));
    }

    private double GetOrCalculateNewWeightedDistance(
        BaseType baseType,
        SubjectDistributionModel subjectDistributionModel,
        Bases bases)
    {
        if (subjectDistributionModel.WeightedDistancesToBases.TryGetValue(baseType, out var value) && value.HasValue)
        {
            return value.Value;
        }

        value = _weightedDistanceToBaseCalculationService.Calculate(subjectDistributionModel.Subject, bases[baseType]);
        subjectDistributionModel.WeightedDistancesToBases.Add(baseType, value);

        return value.Value;
    }
}