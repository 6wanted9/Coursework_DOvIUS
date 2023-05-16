using TaskRunner.Interfaces.GeneralDataTypesFillers;
using TaskRunner.Interfaces.ParametersFillers.SpecificParametersFillers;
using TaskRunner.Models;

namespace TaskRunner.Services.ParametersFillers.SpecificParametersFillers;

internal class RegularTaskParametersFiller : ISpecificParametersFiller
{
    private readonly IIntValueFiller _intValueFiller;

    public RegularTaskParametersFiller(IIntValueFiller intValueFiller)
    {
        _intValueFiller = intValueFiller;
    }

    public void Fill(TaskParameters parameters)
    {
        parameters.SubjectsAmount = _intValueFiller.Fill("Enter Subjects Amount: ");
        parameters.MaxSubjectWeight = _intValueFiller.Fill("Enter Max Subject Weight: ");
    }
}