using Core.Creeps.UseCase;
using UnityEngine;

namespace Core.Turrets.Views
{
    public class ProjectileController
    {
        private ProjectileView _view;
        private CreepReceivedRegularProjectileUseCase _useCase;

        public ProjectileController(ProjectileView view)
        {
            _view = view;

            _view.CollidedWithCreep += OnCollidedWithCreep;
            _useCase = new CreepReceivedRegularProjectileUseCase();
            
            _view.Dispose += OnViewDisposed;
        }

        private void OnViewDisposed()
        {
            _view.CollidedWithCreep -= OnCollidedWithCreep;
            _view = null;
            _useCase = null;
        }

        private void OnCollidedWithCreep(int instanceId)
        {
            _useCase.Execute(instanceId, _view.GetInstanceID());//TODO: use factory to decide what type of projectile, create use case based on that
            //Object.Destroy(_view); //TODO: implement pool release
        }
    }
}