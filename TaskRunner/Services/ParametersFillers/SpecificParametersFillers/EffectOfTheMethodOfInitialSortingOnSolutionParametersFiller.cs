using TaskRunner.Interfaces.GeneralDataTypesFillers;
using TaskRunner.Interfaces.ParametersFillers.SpecificParametersFillers;
using TaskRunner.Models;

namespace TaskRunner.Services.ParametersFillers.SpecificParametersFillers;

internal class EffectOfTheMethodOfInitialSortingOnSolutionParametersFiller : ISpecificParametersFiller
{
    private readonly IIntValueFiller _intValueFiller;

    public EffectOfTheMethodOfInitialSortingOnSolutionParametersFiller(IIntValueFiller intValueFiller)
    {
        _intValueFiller = intValueFiller;
    }

    public void Fill(TaskParameters parameters)
    {
        parameters.SubjectsAmount = _intValueFiller.Fill("Enter Subjects Amount: ");
        parameters.MaxSubjectWeight = _intValueFiller.Fill("Enter Max Subject Weight: ");
    }
}