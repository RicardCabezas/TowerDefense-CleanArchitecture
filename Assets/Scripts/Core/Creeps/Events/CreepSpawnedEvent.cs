using Core.Creeps.Entities;
using Events;

namespace Core.Creeps.Events
{
    public struct CreepSpawnedEvent : BaseEvent
    {
        public CreepEntity Creep { get; }

        public CreepSpawnedEvent(CreepEntity creep)
        {
            Creep = creep;
        }
    }
}