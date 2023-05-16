using CourseworkTask.Models;

namespace CourseworkTask.Interfaces;

public interface ITaskConditionsGenerator
{
    List<TaskConditions> Generate(int tasksAmount, int? subjectsAmount, int? maxWeight);

    TaskConditions Generate(int? subjectsAmount, int? maxWeight);

    TaskConditions GenerateSpecificCase();
}