using CourseworkTask.Interfaces;
using CourseworkTask.Models;

namespace CourseworkTask.Services;

internal class WeightedDistanceToBaseCalculationService : IWeightedDistanceToBaseCalculationService
{
    public double Calculate(Subject subject, Base @base)
    {
        return subject.Weight * (subject.Coordinates - @base.Coordinates);
    }
}