using Core.Creeps.Entities;
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
            
            _eventDispatcher = ServiceLocator.ServiceLocator.Instance.GetService<IEventDispatcher>();
        }

        public void UpdateTarget(int creepInstanceId, int turretInstanceId)
        {
            var target = _creepRepository.GetCreepEntity(creepInstanceId);
            var turretEntity = _turretsRepository.GetTurretEntity(turretInstanceId);
            turretEntity.Target = target;

            _eventDispatcher.Dispatch(new TurretTargetUpdated(turretEntity));
        }
    }
}