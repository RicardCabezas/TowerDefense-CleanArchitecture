using System.Collections.Generic;
using Core.Turrets.Entities;
using Core.Turrets.Events;
using Events;

namespace Core.Turrets.UseCases
{
    public class MovingProjectilesController
    {
        List<ProjectileEntity> _movingProjectile = new List<ProjectileEntity>();
        private readonly MoveProjectileUseCase _moveProjectileUseCase;
        private readonly IEventDispatcher _eventDispatcher;

        public MovingProjectilesController()
        {
            var turretsRepository = ServiceLocator.Instance.GetService<TurretsRepository>();
            _moveProjectileUseCase = new MoveProjectileUseCase(turretsRepository);
            
            _eventDispatcher = ServiceLocator.Instance.GetService<IEventDispatcher>();
            _eventDispatcher.Subscribe<ProjectileSpawned>(OnProjectileSpawned);
            _eventDispatcher.Subscribe<ProjectileDestroyed>(OnProjectileDestroyed);
        }

        private void OnProjectileDestroyed(ProjectileDestroyed eventInfo)
        {
            _movingProjectile.Remove(eventInfo.Projectile);
        }

        private void OnProjectileSpawned(ProjectileSpawned eventInfo) //TODO: also remove
        {
            _movingProjectile.Add(eventInfo.Projectile);
        }

        public void Update()
        {
            foreach (var projectile in _movingProjectile)
            {
                _moveProjectileUseCase.Move(projectile);
            }
        }
    }
}