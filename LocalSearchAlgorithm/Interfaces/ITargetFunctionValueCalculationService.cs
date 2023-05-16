using CourseworkTask.Models;
using LocalSearchAlgorithm.Models;

namespace LocalSearchAlgorithm.Interfaces;

internal interface ITargetFunctionValueCalculationService
{
    double Calculate(SubjectDistributionModel[] distributions, TaskConditions task);
}