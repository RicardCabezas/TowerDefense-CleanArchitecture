using Core.Turrets.Entities;
using Core.Turrets.Events;
using Events;

namespace Core.Turrets.UseCases
{
    public class UpdateTurretTargetUseCase
    {
        private readonly CreepRepository _creepRepository;
        private readonly TurretsRepository _turretsRepository;
        private readonly ITurretShootUseCase _turretShootUseCase;
        private readonly IEventDispatcher _eventDispatcher;

        public UpdateTurretTargetUseCase(
            CreepRepository creepRepository, 
            TurretsRepository turretsRepository)
        {
            _creepRepository = creepRepository;
            _turretsRepository = turretsRepository;
            
            _eventDispatcher = ServiceLocator.Instance.GetService<IEventDispatcher>();
        }

        public void UpdateTarget(int creepInstanceId, int turretInstanceId) //TODO: find Entity
        {
            var target = _creepRepository.GetCreepEntity(creepInstanceId);
            var turretEntity = _turretsRepository.GetTurretEntity(turretInstanceId);
            turretEntity.Target = target; //TODO: move to repository (?)

            _eventDispatcher.Dispatch(new TurretTargetUpdated(turretEntity));
        }
    }
}