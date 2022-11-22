using Events;

public struct CreepSpawnedEvent : BaseEvent
{
    public CreepEntity Creep { get; }

    public CreepSpawnedEvent(CreepEntity creep)
    {
        Creep = creep;
    }
}