using Autofac;
using Autofac.Core;
using TaskRunner.Interfaces;

namespace TaskRunner.Services;

internal class Factory<TService> : IFactory<TService>
{
    private readonly IComponentContext _componentContext;

    public Factory(IComponentContext componentContext)
    {
        _componentContext = componentContext;
    }

    public TService CreateService(object key)
    {
        return (TService)_componentContext.ResolveService(new KeyedService(key, typeof(TService)));
    }
}