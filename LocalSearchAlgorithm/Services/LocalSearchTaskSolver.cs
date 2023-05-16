using CourseworkTask.Enums;
using CourseworkTask.Models;
using LocalSearchAlgorithm.Interfaces;
using LocalSearchAlgorithm.Models;

namespace LocalSearchAlgorithm.Services;

internal class LocalSearchTaskSolver : ILocalSearchTaskSolver
{
    private readonly ITargetFunctionValueCalculationService _targetFunctionValueCalculationService;

    public LocalSearchTaskSolver(ITargetFunctionValueCalculationService targetFunctionValueCalculationService)
    {
        _targetFunctionValueCalculationService = targetFunctionValueCalculationService;
    }

    public SolvedTaskModel Solve(TaskConditions task, int? iterationsNumber = null)
    {
        var subjectsAmount = task.Subjects.Count();
        var distributions = task.Subjects.Select(s => new SubjectDistributionModel { Subject = s }).ToArray();
        for (var i = 0; i < subjectsAmount; i++)
        {
            distributions[i].BaseAssignment = (BaseType) (i % 2);
        }

        var targetFunctionValue = _targetFunctionValueCalculationService.Calculate(distributions, task);

        var random = new Random();
        for (var i = 0; i < (iterationsNumber ?? Math.Pow(subjectsAmount, 2)); i++)
        {
            var index = random.Next(task.Subjects.Count);
            distributions[index].BaseAssignment = 1 - distributions[index].BaseAssignment;
            var newTargetFunctionValue = _targetFunctionValueCalculationService.Calculate(distributions, task);

            if (newTargetFunctionValue < targetFunctionValue)
            {
                targetFunctionValue = newTargetFunctionValue;
            }
            else
            {
                distributions[index].BaseAssignment = 1 - distributions[index].BaseAssignment;
            }
        }
        
        return new SolvedTaskModel(
            distributions
                .Where(d => d.BaseAssignment == BaseType.A)
                .ToDictionary(k => k.Subject, k => k.WeightedDistancesToBases[BaseType.A]!.Value),
            distributions
                .Where(d => d.BaseAssignment == BaseType.B)
                .ToDictionary(k => k.Subject, k => k.WeightedDistancesToBases[BaseType.B]!.Value));
    }
}