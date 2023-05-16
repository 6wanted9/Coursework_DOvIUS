using Autofac;
using CourseworkTask;
using GreedyAlgorithm.Services;

namespace GreedyAlgorithm;

public class GreedyAlgorithmModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.AddScopedAsImplementedInterfaces<GreedyTaskSolver>();

        base.Load(builder);
    }
}