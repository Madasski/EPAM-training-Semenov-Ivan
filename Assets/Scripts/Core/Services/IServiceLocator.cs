namespace Core.Services
{
    public interface IServiceLocator
    {
        T Get<T>() where T : IService;
        void Register<T>(T service) where T : IService;
    }
}