using TaskRunner.Models;

namespace TaskRunner.Interfaces.RunningActions.SpecificTaskRunners;

public interface ISpecificTaskRunner
{
    void Run(TaskParameters parameters);
}