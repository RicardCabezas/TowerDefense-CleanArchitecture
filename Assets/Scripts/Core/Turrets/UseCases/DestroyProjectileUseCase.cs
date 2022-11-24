using Core.Turrets.Entities;
using Core.Turrets.Events;
using Events;

namespace Core.Turrets.UseCases
{
    public class DestroyProjectileUseCase
    {
        private readonly ProjectilesRepository _repository;
        private readonly IEventDispatcher _eventDispatcher;

        public DestroyProjectileUseCase()
        {
            _eventDispatcher = ServiceLocator.Instance.GetService<IEventDispatcher>();

            _repository = ServiceLocator.Instance.GetService<ProjectilesRepository>();
        }

        public void Destroy(int instanceId)
        {
            var projectile = _repository.GetProjectileEntity(instanceId);
            _eventDispatcher.Dispatch(new ProjectileDestroyed(projectile));

            _repository.DestroyProjectile(instanceId);
        }
    }
}