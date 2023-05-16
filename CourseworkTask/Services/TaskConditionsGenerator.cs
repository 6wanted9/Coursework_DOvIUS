using CourseworkTask.Interfaces;
using CourseworkTask.Models;
using CourseworkTask.Utils;

namespace CourseworkTask.Services;

internal class TaskConditionsGenerator : ITaskConditionsGenerator
{
    private const int FirstSubjectNumber = 1;
    private const int MinWeight = 1;
    private const int MinNumberOfRandomlyGeneratedSubjectsAmount = 2;
    private const int MaxNumberOfRandomlyGeneratedSubjectsAmount = 60;

    public List<TaskConditions> Generate(int tasksAmount, int? subjectsAmount, int? maxWeight)
    {
        var random = new Random();
        subjectsAmount ??= random.Next(
            MinNumberOfRandomlyGeneratedSubjectsAmount,
            MaxNumberOfRandomlyGeneratedSubjectsAmount);
        maxWeight ??= random.Next(MinWeight, subjectsAmount.Value);
        
        return Enumerable.Range(0, tasksAmount).Select(n => Generate(subjectsAmount, maxWeight)).ToList();
    }

    public TaskConditions Generate(int? subjectsAmount, int? maxWeight)
    {
        var random = new Random();
        subjectsAmount ??= random.Next(
            MinNumberOfRandomlyGeneratedSubjectsAmount,
            MaxNumberOfRandomlyGeneratedSubjectsAmount);
        maxWeight ??= random.Next(MinWeight, subjectsAmount.Value);

        return GenerateTaskCondition(subjectsAmount.Value, maxWeight.Value);
    }

    private TaskConditions GenerateTaskCondition(int subjectsAmount, int maxWeight)
    {
        return new TaskConditions(
            new Bases(new Base(CoordinatesUtils.GenerateRandomCoordinates()), new Base(CoordinatesUtils.GenerateRandomCoordinates())),
            GenerateSubjects(subjectsAmount, maxWeight));
    }

    public TaskConditions GenerateSpecificCase()
    {
        return new TaskConditions(
            new Bases(new Base(CoordinatesUtils.Generate(7, 0)), new Base(CoordinatesUtils.Generate(0, 9))),
            new List<Subject>
            {
                new(1, CoordinatesUtils.Generate(7, 5), 5),
                new(2, CoordinatesUtils.Generate(0, 0), 4),
                new(3, CoordinatesUtils.Generate(2, 0), 1),
                new(4, CoordinatesUtils.Generate(4, 3), 2),
                new(5, CoordinatesUtils.Generate(2, 8), 3),
                new(6, CoordinatesUtils.Generate(9, 3), 6),
            });
    }

    private List<Subject> GenerateSubjects(int subjectsAmount, int maxWeight)
    {
        var random = new Random();
        var subjectsNumbers = Enumerable.Range(FirstSubjectNumber, subjectsAmount);

        return subjectsNumbers.Select(number => new Subject(
            number,
            CoordinatesUtils.GenerateRandomCoordinates(),
            random.Next(MinWeight, maxWeight))).ToList();
    }
}