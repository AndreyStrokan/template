public interface IServiceResolver
{
    T Resolve<T>() where T : IService;
}
