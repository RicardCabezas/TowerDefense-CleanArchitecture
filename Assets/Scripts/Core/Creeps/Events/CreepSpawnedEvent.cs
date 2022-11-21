using Events;

public class CreepSpawnedEvent : BaseEvent
{
    public CreepEntity Creep { get; }

    public CreepSpawnedEvent(CreepEntity creep)
    {
        Creep = creep;
    }
}