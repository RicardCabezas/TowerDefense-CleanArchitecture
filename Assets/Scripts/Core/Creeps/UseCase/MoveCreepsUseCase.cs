using System.Threading.Tasks;
using Events;
using UnityEngine;

public class MoveCreepsUseCase
{
    private readonly CreepRepository _creepRepository;
    private readonly Transform _userBaseTransform;
    private readonly IEventDispatcher _eventDispatcher;

    public MoveCreepsUseCase(CreepRepository creepRepository, Transform userBaseTransform) //TODO: get from repository(?)
    {
        _creepRepository = creepRepository;
        _userBaseTransform = userBaseTransform;

        _eventDispatcher = ServiceLocator.Instance.GetService<IEventDispatcher>();
        _eventDispatcher.Subscribe<CreepSpawnedEvent>(OnCreepSpawned);
    }

    private void OnCreepSpawned(CreepSpawnedEvent eventInfo)
    {
        Move(eventInfo.Creep);
    }

    public async void Move(CreepEntity creep)
    {
        creep.TargetPosition = _userBaseTransform.position;
        
        while (Vector3.Distance(creep.CurrentPosition, _userBaseTransform.position) >= 1)
        {
            var newCreepPosition = Vector3.MoveTowards(
                creep.CurrentPosition, creep.TargetPosition, creep.CurrentSpeed * Time.deltaTime);
            creep.CurrentPosition = newCreepPosition;
            
            _eventDispatcher.Dispatch(new CreepMovedEvent(creep));
            await Task.Yield();
        }
        
        //TODO: call event of creep arrived to Target
    }
}