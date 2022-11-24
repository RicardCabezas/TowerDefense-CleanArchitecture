using Core.Creeps.UseCase;
using Core.Turrets.UseCases;
using Core.Turrets.Views.Projectile;
using Pool.BaseObjectRepresentation;

namespace Core.Turrets.Controllers.Projectiles
{
    public class ProjectileController : BaseViewController
    {
        protected ProjectileView _view;
        protected ICreepReceivedProjectile _useCase;
        protected DestroyProjectileUseCase _destroyProjectile;

        public ProjectileController(ProjectileView view)
        {
            _view = view;

            _view.CollidedWithCreep += OnCollidedWithCreep;
            _useCase = new CreepReceivedRegularProjectileUseCase();
            _destroyProjectile = new DestroyProjectileUseCase();
            _view.Dispose += OnViewDisposed;
        }

        protected void OnViewDisposed()
        {
            _view.CollidedWithCreep -= OnCollidedWithCreep;
            _view = null;
            _useCase = null;
        }

        protected void OnCollidedWithCreep(int instanceId)
        {
            _useCase.Execute(instanceId, _view.GetInstanceID());
            _destroyProjectile.Destroy(_view.GetInstanceID());
        }
    }
}