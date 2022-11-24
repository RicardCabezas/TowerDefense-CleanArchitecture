using System;

namespace Events
{
    public interface IEventDispatcher //TODO: use Interface callbacks to avoid create a NEW event each time
    {
        void Subscribe<T>(Action<T> callback) where T : BaseEvent;
        void Unsubscribe<T>(Action<T> callback) where T : BaseEvent;
        void Dispatch<T>(T arg = default) where T : BaseEvent;
    }
}