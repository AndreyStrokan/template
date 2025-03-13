using System;
using System.Collections.Generic;

public class ServiceContainer : IServiceResolver, IServiceRegistrar, IDisposable
{
    private Dictionary<Type, IService> services = new();

    public void Register<T>(T service) where T : IService
    {
        services.Add(typeof(T), service);
    }

    public T Resolve<T>() where T : IService
    {
        return (T) services[typeof(T)];
    }

    public void Dispose()
    {
        foreach (var service in services)
        {
            service.Value.Dispose();
        }

        services.Clear();
        services = null;
    }
}
