using TaskRunner.Models;

namespace TaskRunner.Interfaces.ParametersFillers.SpecificParametersFillers;

public interface ISpecificParametersFiller
{
    void Fill(TaskParameters parameters);
}