using Core.BaseCamp.Events;
using Core.Creeps.Entities;
using Core.Creeps.Events;
using Events;
using UnityEngine;

namespace Core.Creeps.UseCase
{
    public class MoveCreepsUseCase
    {
        private readonly CreepRepository _creepRepository;
        private readonly Transform _userBaseTransform;
        private readonly IEventDispatcher _eventDispatcher;

        public MoveCreepsUseCase(CreepRepository creepRepository, Transform userBaseTransform)
        {
            _creepRepository = creepRepository;
            _userBaseTransform = userBaseTransform;
            _eventDispatcher = ServiceLocator.ServiceLocator.Instance.GetService<IEventDispatcher>();
        }

        public void Move(CreepEntity creep)
        {
            creep.TargetPosition = _userBaseTransform.position;

            var newCreepPosition = Vector3.MoveTowards(
                creep.CurrentPosition, creep.TargetPosition, creep.CurrentSpeed * Time.deltaTime);
            creep.CurrentPosition = newCreepPosition;

            _eventDispatcher.Dispatch(new CreepMovedEvent(creep));

            if ((Vector3.Distance(creep.CurrentPosition, _userBaseTransform.position) >= 1))
                return;

            var damage = _creepRepository.GetCreepConfig(creep.Id).Damage;
            _eventDispatcher.Dispatch(new BaseCampReceivedDamageEvent(damage));
        }
    }
}