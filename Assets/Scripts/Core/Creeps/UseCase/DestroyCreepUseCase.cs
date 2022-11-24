using Core.Currencies.Events;
using Core.Turrets.Entities;
using Events;

public class DestroyCreepUseCase
{
    private readonly CreepRepository _repository;
    private readonly IEventDispatcher _eventDispatcher;
    private readonly IEconomySystem<SoftCurrency> _softCurrency;

    public DestroyCreepUseCase()
    {
        _eventDispatcher = ServiceLocator.Instance.GetService<IEventDispatcher>();
        _repository = ServiceLocator.Instance.GetService<CreepRepository>();
        _softCurrency = ServiceLocator.Instance.GetService<IEconomySystem<SoftCurrency>>();
    }
    
    public void Destroy(int instanceId)
    {
        var creepEntity = _repository.GetCreepEntity(instanceId);
        
        _softCurrency.AddCurrency(creepEntity.Reward);
        _eventDispatcher.Dispatch(new UpdateSoftCurrencyEvent(_softCurrency.CurrentAmount));

        _eventDispatcher.Dispatch(new CreepDestroyedEvent(creepEntity));
        _repository.DestroyCreep(instanceId);
    }
}