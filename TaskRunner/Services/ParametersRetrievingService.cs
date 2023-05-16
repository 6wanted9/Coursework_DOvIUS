using TaskRunner.Enums;
using TaskRunner.Interfaces;
using TaskRunner.Interfaces.GeneralDataTypesFillers;
using TaskRunner.Interfaces.ParametersFillers.SpecificParametersFillers;
using TaskRunner.Models;

namespace TaskRunner.Services;

internal class ParametersRetrievingService : IParametersRetrievingService
{
    private readonly IEnumValueFiller _enumValueFiller;
    private readonly IFactory<ISpecificParametersFiller> _specificParametersFillerFactory;

    public ParametersRetrievingService(
        IEnumValueFiller enumValueFiller,
        IFactory<ISpecificParametersFiller> specificParametersFillerFactory)
    {
        _enumValueFiller = enumValueFiller;
        _specificParametersFillerFactory = specificParametersFillerFactory;
    }

    public TaskParameters Get()
    {
        var parameters = new TaskParameters
        {
            ExecutionType = _enumValueFiller.Fill<ExecutionType>(
                "Choose Execution Type from types above (enter number): "),
            DataGenerationType = _enumValueFiller.Fill<DataGenerationType>(
                "Choose Data Generation Type from types above (enter number): ")
        };

        if (parameters.DataGenerationType == DataGenerationType.Random)
        {
            return parameters;
        }

        _specificParametersFillerFactory.CreateService(parameters.ExecutionType).Fill(parameters);

        return parameters;
    }
}