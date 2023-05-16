using CourseworkTask.Models;

namespace GreedyAlgorithm.Interfaces;

public interface IGreedyTaskSolver
{
    SolvedTaskModel Solve(TaskConditions task, bool ascendingInitialOrder = false);
}