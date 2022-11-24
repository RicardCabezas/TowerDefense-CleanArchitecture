using Core.Turrets.Entities;
using Core.Turrets.Events;
using Events;

namespace Core.Turrets.UseCases
{
    public class TurretShootUseCaseUse
    {
        private readonly ProjectilesRepository _repository;
        private readonly IEventDispatcher _eventDispatcher;

        public TurretShootUseCaseUse(ProjectilesRepository repository)
        {
            _repository = repository;
            
            _eventDispatcher = ServiceLocator.ServiceLocator.Instance.GetService<IEventDispatcher>();

        }
        public void Shoot(TurretEntity turretEntity)
        {
            var projectile = _repository.SpawnNewProjectile(turretEntity);
            _eventDispatcher.Dispatch(new ProjectileSpawned(projectile));
        }
    }
}