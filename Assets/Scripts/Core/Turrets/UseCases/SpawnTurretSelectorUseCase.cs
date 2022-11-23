using Core.Turrets.Configs;
using Core.Turrets.Entities;
using Core.Turrets.Events;
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
        
        public void Spawn(TurretsRepository turretsRepository, TurretsConfig turretsConfig)
        {
            foreach (var turret in turretsConfig.Turrets)
            {
                turretsRepository.SpawnNewTurretThumbnail(turret.Id);
                _eventDispatcher.Dispatch(new TurretSelectorSpawned(turret));
            }
        }
    }
}