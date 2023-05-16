using Autofac;
using CourseworkTask;
using TaskRunner.Enums;
using TaskRunner.Interfaces.ParametersFillers.SpecificParametersFillers;
using TaskRunner.Interfaces.RunningActions.SpecificTaskRunners;
using TaskRunner.Services;
using TaskRunner.Services.ParametersFillers.GeneralDataTypesFillers;
using TaskRunner.Services.ParametersFillers.SpecificParametersFillers;
using TaskRunner.Services.RunningActions.SpecificTaskRunners;

namespace TaskRunner;

public class TaskRunnerModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.AddScopedAsImplementedInterfaces<TaskRunningService>();
        builder.AddScopedAsImplementedInterfaces<ParametersRetrievingService>();
        builder.AddScopedAsImplementedInterfaces<Factory<ISpecificParametersFiller>>();
        builder.AddScopedAsImplementedInterfaces<Factory<ISpecificTaskRunner>>();
        builder.AddScopedAsImplementedInterfaces<EnumValueFiller>();
        builder.AddScopedAsImplementedInterfaces<IntValueFiller>();
        RegisterSpecificParametersFillers(builder);
        RegisterSpecificTaskRunners(builder);

        base.Load(builder);
    }

    private ContainerBuilder RegisterSpecificParametersFillers(ContainerBuilder builder)
    {
        builder.RegisterWithKey<RegularTaskParametersFiller, ISpecificParametersFiller>(ExecutionType.RegularTask);
        builder.RegisterWithKey<
            EffectOfTheMethodOfInitialSortingOnSolutionParametersFiller,
            ISpecificParametersFiller>(ExecutionType.EffectOfTheMethodOfInitialSortingOnSolution);
        builder.RegisterWithKey<
            EffectOfNumberOfIterationsOnSolutionParametersFiller,
            ISpecificParametersFiller>(ExecutionType.EffectOfNumberOfIterationsOnSolution);
        builder.RegisterWithKey<
            EffectOfTaskSizeOnTimeParametersFiller,
            ISpecificParametersFiller>(ExecutionType.EffectOfTaskSizeOnTime);
        builder.RegisterWithKey<
            EffectOfTaskSizeOnSolutionParametersFiller,
            ISpecificParametersFiller>(ExecutionType.EffectOfTaskSizeOnSolution);
        builder.RegisterWithKey<
            EffectOfMaxWeightOnSolutionParametersFiller,
            ISpecificParametersFiller>(ExecutionType.EffectOfMaxWeightOnSolution);

        return builder;
    }

    private ContainerBuilder RegisterSpecificTaskRunners(ContainerBuilder builder)
    {
        builder.RegisterWithKey<RegularTaskRunner, ISpecificTaskRunner>(ExecutionType.RegularTask);
        builder.RegisterWithKey<
            EffectOfTheMethodOfInitialSortingOnSolutionTaskRunner,
            ISpecificTaskRunner>(ExecutionType.EffectOfTheMethodOfInitialSortingOnSolution);
        builder.RegisterWithKey<
            EffectOfNumberOfIterationsOnSolutionTaskRunner,
            ISpecificTaskRunner>(ExecutionType.EffectOfNumberOfIterationsOnSolution);
        builder.RegisterWithKey<
            EffectOfTaskSizeOnTimeTaskRunner,
            ISpecificTaskRunner>(ExecutionType.EffectOfTaskSizeOnTime);
        builder.RegisterWithKey<
            EffectOfTaskSizeOnSolutionTaskRunner,
            ISpecificTaskRunner>(ExecutionType.EffectOfTaskSizeOnSolution);
        builder.RegisterWithKey<
            EffectOfMaxWeightOnSolutionTaskRunner,
            ISpecificTaskRunner>(ExecutionType.EffectOfMaxWeightOnSolution);

        return builder;
    }
}