using Events;

public class CreepMovedEvent : BaseEvent
{
    public CreepEntity Creep { get; }

    public CreepMovedEvent(CreepEntity creep)
    {
        Creep = creep;
    }
}
