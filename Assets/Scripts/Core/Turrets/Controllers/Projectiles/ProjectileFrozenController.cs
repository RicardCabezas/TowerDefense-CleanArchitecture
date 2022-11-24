using Core.Creeps.UseCase;
using Core.Turrets.UseCases;
using Core.Turrets.Views.Projectile;

namespace Core.Turrets.Controllers.Projectiles
{
    public class ProjectileFrozenController : ProjectileController
    {
        public ProjectileFrozenController(ProjectileView view) : base(view)
        {
            _view = view;

            _view.CollidedWithCreep += OnCollidedWithCreep;
            _useCase = new CreepReceivedFrozenProjectileUseCase();
            _destroyProjectile = new DestroyProjectileUseCase();
            _view.Dispose += OnViewDisposed;
        }
    }
}