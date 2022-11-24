using Core.Creeps.Entities;
using Events;

namespace Core.Creeps.Events
{
    public struct CreepDestroyedEvent : BaseEvent
    {
        public CreepEntity Creep { get; }

        public CreepDestroyedEvent(CreepEntity creep)
        {
            Creep = creep;
        }
    }
}