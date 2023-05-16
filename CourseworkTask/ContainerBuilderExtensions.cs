using Autofac;

namespace CourseworkTask;

public static class ContainerBuilderExtensions
{
    public static ContainerBuilder AddScopedAsImplementedInterfaces<TService>(this ContainerBuilder builder)
    {
        builder.RegisterType<TService>()
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();

        return builder;
    }

    public static ContainerBuilder RegisterWithKey<TService, TInterface>(
        this ContainerBuilder builder,
        object key)
    {
        builder.RegisterType<TService>()
            .Keyed<TInterface>(key)
            .InstancePerLifetimeScope();

        return builder;
    }
}