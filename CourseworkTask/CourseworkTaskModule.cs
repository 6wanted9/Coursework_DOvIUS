using Autofac;
using CourseworkTask.Services;

namespace CourseworkTask;

public class CourseworkTaskModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.AddScopedAsImplementedInterfaces<TaskConditionsGenerator>();
        builder.AddScopedAsImplementedInterfaces<TaskConditionsForDisplayBuilder>();
        builder.AddScopedAsImplementedInterfaces<SolvedTaskForDisplayBuilder>();
        builder.AddScopedAsImplementedInterfaces<WeightedDistanceToBaseCalculationService>();

        base.Load(builder);
    }
}