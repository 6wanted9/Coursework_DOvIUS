using CourseworkTask.Models;

namespace CourseworkTask.Interfaces;

public interface ITaskConditionsForDisplayBuilder
{
    public string Build(TaskConditions task);
}