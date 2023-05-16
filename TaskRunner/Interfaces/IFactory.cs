namespace TaskRunner.Interfaces;

public interface IFactory<TService>
{
    TService CreateService(object key);
}