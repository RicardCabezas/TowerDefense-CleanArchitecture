using Core.Turrets.Configs;
using Core.Turrets.Entities;
using Core.Turrets.Events;
using Core.Turrets.Views;
using Events;

namespace Core.Turrets.UseCases
{
    public class SpawnTurretSelectorUseCase
    {
        private readonly IEventDispatcher _eventDispatcher;

        public SpawnTurretSelectorUseCase()
        {
            _eventDispatcher = ServiceLocator.Instance.GetService<IEventDispatcher>();
            //TODO: subscribe on game initialized
        }
        
        public void Spawn(TurretsRepository turretsRepository, TurretsConfig turretsConfig,
            TurretSpawnerPreviewerController turretSpawnerPreviewerController)
        {
            foreach (var turret in turretsConfig.Turrets)
            {
                turretsRepository.SpawnNewTurretThumbnail(turret.Id, turretSpawnerPreviewerController); //TODO: remove controller, move to group
                _eventDispatcher.Dispatch(new TurretSelectorSpawned(turret));
            }
        }
    }
}