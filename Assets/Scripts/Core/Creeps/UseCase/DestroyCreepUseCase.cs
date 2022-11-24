using Core.Turrets.Entities;
using Events;

public class DestroyCreepUseCase
{
    private readonly CreepRepository _repository;
    private readonly IEventDispatcher _eventDispatcher;

    public DestroyCreepUseCase()
    {
        _eventDispatcher = ServiceLocator.Instance.GetService<IEventDispatcher>();
        _repository = ServiceLocator.Instance.GetService<CreepRepository>();
    }
    
    public void Destroy(int instanceId)
    {
        var creepEntity = _repository.GetCreepEntity(instanceId);
        _eventDispatcher.Dispatch(new CreepDestroyedEvent(creepEntity));
        _repository.DestroyCreep(instanceId);
    }
}