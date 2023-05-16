using CourseworkTask.Models;

namespace LocalSearchAlgorithm.Interfaces;

public interface ILocalSearchTaskSolver
{
    SolvedTaskModel Solve(TaskConditions task, int? iterationsNumber = null);
}