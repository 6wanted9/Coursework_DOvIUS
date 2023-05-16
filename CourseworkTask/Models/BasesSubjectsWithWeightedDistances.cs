using CourseworkTask.Enums;

namespace CourseworkTask.Models;

public class BasesSubjectsWithWeightedDistances
{
    private Dictionary<Subject, double> _baseASubjectsWithWeightedDistances { get; }

    private Dictionary<Subject, double> _baseBSubjectsWithWeightedDistances { get; }

    public BasesSubjectsWithWeightedDistances(
        Dictionary<Subject, double> baseASubjectsWithWeightedDistances,
        Dictionary<Subject, double> baseBSubjectsWithWeightedDistances)
    {
        _baseASubjectsWithWeightedDistances = baseASubjectsWithWeightedDistances;
        _baseBSubjectsWithWeightedDistances = baseBSubjectsWithWeightedDistances;
    }

    public Dictionary<Subject, double> this[BaseType baseType] => baseType == BaseType.A
        ? _baseASubjectsWithWeightedDistances
        : _baseBSubjectsWithWeightedDistances;
}