using Events;

public class CreepPresenter : BasePresenter
{
    private CreepView _view;
    private IEventDispatcher _eventDispatcher;

    public CreepPresenter(CreepView view)
    {
        _view = view;

        _eventDispatcher = ServiceLocator.Instance.GetService<IEventDispatcher>();
        
        _eventDispatcher.Subscribe<CreepSpawnedEvent>(OnCreepSpawned);
        _eventDispatcher.Subscribe<CreepMovedEvent>(OnCreepMoved);
        
        _view.Dispose += OnViewDisposed;
    }

    private void OnCreepMoved(CreepMovedEvent eventInfo) //TODO: make a presenters container to avoid calling all presenters
    {
        if(eventInfo.Creep.InstanceId != _view.GetInstanceID())
            return;
        
        _view.transform.position = eventInfo.Creep.CurrentPosition;
        _view.transform.LookAt(eventInfo.Creep.TargetPosition);
    }

    private void OnCreepSpawned(CreepSpawnedEvent eventInfo)
    {
        _view.transform.position = eventInfo.Creep.CurrentPosition;
    }
    
    private void OnViewDisposed()
    {
        Dispose();
        _view = null;
    }

    public override void Dispose()
    {
        if (_eventDispatcher != null)
        {
            _eventDispatcher.Unsubscribe<CreepSpawnedEvent>(OnCreepSpawned);
            _eventDispatcher.Unsubscribe<CreepMovedEvent>(OnCreepMoved);        
            _eventDispatcher = null;
        }
    }
}