using Core.Creeps.UseCase;
using UnityEngine;

namespace Core.Turrets.Views
{
    public class ProjectileController
    {
        private readonly ProjectileView _view;
        private readonly CreepReceivedRegularProjectileUseCase _useCase;

        public ProjectileController(ProjectileView view)
        {
            _view = view;

            _view.CollidedWithCreep += OnCollidedWithCreep;
            _useCase = new CreepReceivedRegularProjectileUseCase();

        }

        private void OnCollidedWithCreep(int instanceId)
        {
            _useCase.Execute(instanceId, _view.GetInstanceID());//TODO: use factory to decide what type of projectile, create use case based on that
            //Object.Destroy(_view); //TODO: implement pool release
        }
    }
}