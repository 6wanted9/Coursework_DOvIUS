using Autofac;
using CourseworkTask;
using LocalSearchAlgorithm.Services;

namespace LocalSearchAlgorithm;

public class DynamicProgrammingAlgorithmModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.AddScopedAsImplementedInterfaces<LocalSearchTaskSolver>();
        builder.AddScopedAsImplementedInterfaces<TargetFunctionValueCalculationService>();

        base.Load(builder);
    }
}