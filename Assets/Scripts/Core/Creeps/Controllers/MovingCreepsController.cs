using System.Collections.Generic;
using Core.Creeps.Entities;
using Core.Creeps.Events;
using Core.Creeps.UseCase;
using Events;
using Pool.BaseObjectRepresentation;

namespace Core.Creeps.Controllers
{
    public class MovingCreepsController : BaseViewController
    {
        private readonly MoveCreepsUseCase _moveCreepsUseCase;
        private readonly IEventDispatcher _eventDispatcher;

        private List<CreepEntity> _movingCreeps = new List<CreepEntity>();

        public MovingCreepsController(MoveCreepsUseCase moveCreepsUseCase)
        {
            _moveCreepsUseCase = moveCreepsUseCase;
            _eventDispatcher = ServiceLocator.ServiceLocator.Instance.GetService<IEventDispatcher>();
            _eventDispatcher.Subscribe<CreepSpawnedEvent>(OnCreepSpawned);
            _eventDispatcher.Subscribe<CreepDestroyedEvent>(OnCreepDestroyed);
        }

        private void OnCreepDestroyed(CreepDestroyedEvent eventInfo)
        {
            _movingCreeps.Remove(eventInfo.Creep); 
        }

        private void OnCreepSpawned(CreepSpawnedEvent eventInfo)
        {
            _movingCreeps.Add(eventInfo.Creep);
        }

        public void Update()
        {
            foreach (var creep in _movingCreeps)
            {
                _moveCreepsUseCase.Move(creep);
            }
        }
    }
}