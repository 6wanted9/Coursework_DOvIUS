using Autofac;
using CourseworkTask;
using GreedyAlgorithm;
using LocalSearchAlgorithm;
using TaskRunner.Interfaces;

namespace TaskRunner;

public class Program
{
    private static IContainer Container { get; set; }

    public static void Main(string[] args)
    {
        // Setup DI
        var builder = new ContainerBuilder();
        builder.RegisterModule<CourseworkTaskModule>();
        builder.RegisterModule<GreedyAlgorithmModule>();
        builder.RegisterModule<DynamicProgrammingAlgorithmModule>();
        builder.RegisterModule<TaskRunnerModule>();
        Container = builder.Build();

        using (var scope = Container.BeginLifetimeScope())
        {
            var service = scope.Resolve<ITaskRunningService>();
            service.Run();
        }
    }
}