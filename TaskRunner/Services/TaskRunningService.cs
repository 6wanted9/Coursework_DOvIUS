using TaskRunner.Interfaces;
using TaskRunner.Interfaces.RunningActions.SpecificTaskRunners;

namespace TaskRunner.Services;

internal class TaskRunningService : ITaskRunningService
{
    private readonly IParametersRetrievingService _parametersRetrievingService;
    private readonly IFactory<ISpecificTaskRunner> _specificTaskRunnerFactory;

    public TaskRunningService(
        IParametersRetrievingService parametersRetrievingService,
        IFactory<ISpecificTaskRunner> specificTaskRunnerFactory)
    {
        _parametersRetrievingService = parametersRetrievingService;
        _specificTaskRunnerFactory = specificTaskRunnerFactory;
    }

    public void Run()
    {
        var parameters = _parametersRetrievingService.Get();
        _specificTaskRunnerFactory.CreateService(parameters.ExecutionType).Run(parameters);
    }
}