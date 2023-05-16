using TaskRunner.Interfaces.GeneralDataTypesFillers;
using TaskRunner.Interfaces.ParametersFillers.SpecificParametersFillers;
using TaskRunner.Models;

namespace TaskRunner.Services.ParametersFillers.SpecificParametersFillers;

internal class EffectOfMaxWeightOnSolutionParametersFiller : ISpecificParametersFiller
{
    private readonly IIntValueFiller _intValueFiller;

    public EffectOfMaxWeightOnSolutionParametersFiller(IIntValueFiller intValueFiller)
    {
        _intValueFiller = intValueFiller;
    }

    public void Fill(TaskParameters parameters)
    {
        parameters.SubjectsAmount = _intValueFiller.Fill("Enter Subjects Amount: ");
    }
}