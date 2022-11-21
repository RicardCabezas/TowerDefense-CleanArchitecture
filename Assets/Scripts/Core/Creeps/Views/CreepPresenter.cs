using Events;

public class CreepPresenter
{
    private readonly CreepView _view;
    private readonly IEventDispatcher _eventDispatcher;

    //TODO: react and update view
    //on unit received dmg
    //on unit died
    
    //TODO: dispose when view destroyed

    public CreepPresenter(CreepView view)
    {
        _view = view;

        _eventDispatcher = ServiceLocator.Instance.GetService<IEventDispatcher>();
        
        _eventDispatcher.Subscribe<CreepSpawnedEvent>(OnCreepSpawned);
        _eventDispatcher.Subscribe<CreepMovedEvent>(OnCreepMoved);
    }

    private void OnCreepMoved(CreepMovedEvent eventInfo)
    {
        _view.transform.position = eventInfo.Creep.CurrentPosition;
        _view.transform.LookAt(eventInfo.Creep.TargetPosition);
    }

    private void OnCreepSpawned(CreepSpawnedEvent eventInfo)
    {
        _view.transform.position = eventInfo.Creep.CurrentPosition;
    }
}