using TaskRunner.Models;

namespace TaskRunner.Interfaces;

public interface IParametersRetrievingService
{
    TaskParameters Get();
}