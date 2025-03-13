public interface IServiceRegistrar
{
    void Register<T>(T service) where T : IService;
}
