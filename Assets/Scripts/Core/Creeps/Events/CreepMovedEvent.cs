using Core.Creeps.Entities;
using Events;

namespace Core.Creeps.Events
{
    public struct CreepMovedEvent : BaseEvent
    {
        public CreepEntity Creep { get; }

        public CreepMovedEvent(CreepEntity creep)
        {
            Creep = creep;
        }
    }
}
