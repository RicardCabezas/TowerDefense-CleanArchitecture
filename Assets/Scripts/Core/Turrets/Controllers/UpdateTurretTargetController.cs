using Core.Turrets.Events;
using Core.Turrets.UseCases;
using Events;

namespace Core.Turrets.Views
{
    public class UpdateTurretTargetController
    {
        private readonly UpdateTurretTargetUseCase _updateTurretTargetUseCase;
        private readonly IEventDispatcher _eventDispatcher;

        public UpdateTurretTargetController(UpdateTurretTargetUseCase updateTurretTargetUseCase)
        {
            _updateTurretTargetUseCase = updateTurretTargetUseCase;
            
            _eventDispatcher = ServiceLocator.Instance.GetService<IEventDispatcher>();
            _eventDispatcher.Subscribe<CreepEnteredTurretRange>(OnCreepEnteredOnTurretRange);
        }

        private void OnCreepEnteredOnTurretRange(CreepEnteredTurretRange eventData)
        {
            _updateTurretTargetUseCase.UpdateTarget(eventData.CreepInstanceId, eventData.TurretInstanceId);
        }
    }
}