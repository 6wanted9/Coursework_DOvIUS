using CourseworkTask.Models;

namespace CourseworkTask.Interfaces;

public interface IWeightedDistanceToBaseCalculationService
{
    double Calculate(Subject subject, Base @base);
}