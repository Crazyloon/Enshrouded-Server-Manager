namespace Enshrouded_Server_Manager.Events;
public interface IEventAggregator
{
    void Publish<T>(T message) where T : IApplicationEvent;
    void Subscribe<T>(Action<T> action) where T : IApplicationEvent;
    void Unsubscribe<T>(Action<T> action) where T : IApplicationEvent;
}
