namespace SharedCore.Interfaces;

public interface IMessageService
{
    Task PublishEvent<TEvent>(TEvent @event) where TEvent : class;
}