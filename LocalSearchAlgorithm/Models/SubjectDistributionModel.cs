using CourseworkTask.Enums;
using CourseworkTask.Models;

namespace LocalSearchAlgorithm.Models;

internal class SubjectDistributionModel
{
    public BaseType BaseAssignment { get; set; }

    public Subject Subject { get; init; }

    public Dictionary<BaseType, double?> WeightedDistancesToBases { get; } = new();
}