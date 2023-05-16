using CourseworkTask.Models;

namespace CourseworkTask.Interfaces;

public interface ISolvedTaskForDisplayBuilder
{
    string Build(SolvedTaskModel task);
}