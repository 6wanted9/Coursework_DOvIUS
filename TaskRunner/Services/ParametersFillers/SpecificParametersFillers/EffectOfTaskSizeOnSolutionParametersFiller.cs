using TaskRunner.Interfaces.GeneralDataTypesFillers;
using TaskRunner.Interfaces.ParametersFillers.SpecificParametersFillers;
using TaskRunner.Models;

namespace TaskRunner.Services.ParametersFillers.SpecificParametersFillers;

internal class EffectOfTaskSizeOnSolutionParametersFiller : ISpecificParametersFiller
{
    private readonly IIntValueFiller _intValueFiller;

    public EffectOfTaskSizeOnSolutionParametersFiller(IIntValueFiller intValueFiller)
    {
        _intValueFiller = intValueFiller;
    }

    public void Fill(TaskParameters parameters)
    {
        parameters.MaxSubjectWeight = _intValueFiller.Fill("Enter Max Subject Weight: ");
    }
}