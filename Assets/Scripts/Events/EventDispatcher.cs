using System;
using System.Collections.Generic;

namespace Events
{
    public class EventDispatcher : IEventDispatcher
    {
        private readonly Dictionary<Type, dynamic> _events = new Dictionary<Type, dynamic>();
        private readonly Dictionary<Type, int> boooo = new Dictionary<Type, int>();

        public void Subscribe<T>(Action<T> callback) where T : BaseEvent
        {
            var type = typeof(T);
            if (!_events.ContainsKey(type))
            {
                _events.Add(type, null);
            }

            _events[type] += callback;
        }

        public void Unsubscribe<T>(Action<T> callback) where T : BaseEvent
        {
            var type = typeof(T);
            if (_events.ContainsKey(type))
            {
                _events[type] -= callback;
            }
        }

        public void Dispatch<T>(T arg) where T : BaseEvent
        {
            var type = typeof(T);
            if (_events.ContainsKey(typeof(T)))
            {
                var c = _events[type] as Action<T>;
                c?.Invoke(arg);
            }
        }
    }
}