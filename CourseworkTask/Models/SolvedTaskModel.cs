namespace CourseworkTask.Models;

public class SolvedTaskModel
{
    public SolvedTaskModel(
        Dictionary<Subject, double> baseASubjectsWithWeightedDistances,
        Dictionary<Subject, double> baseBSubjectsWithWeightedDistances)
    {
        BasesSubjectsWithWeightedDistances = new BasesSubjectsWithWeightedDistances(
            baseASubjectsWithWeightedDistances,
            baseBSubjectsWithWeightedDistances);
        TargetFunctionValue = Math.Abs(
            baseASubjectsWithWeightedDistances.Sum(s => s.Value) -
            baseBSubjectsWithWeightedDistances.Sum(s => s.Value));
    }

    public BasesSubjectsWithWeightedDistances BasesSubjectsWithWeightedDistances { get; }

    public double TargetFunctionValue { get; }
}