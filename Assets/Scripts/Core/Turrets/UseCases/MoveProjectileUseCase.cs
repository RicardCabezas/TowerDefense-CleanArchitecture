using Core.Turrets.Entities;
using Core.Turrets.Events;
using Events;
using UnityEngine;

namespace Core.Turrets.UseCases
{
    public class MoveProjectileUseCase
    {
        private readonly IEventDispatcher _eventDispatcher;
        private readonly TurretsRepository _repository;

        public MoveProjectileUseCase(TurretsRepository repository)
        {
            _repository = repository;
            
            _eventDispatcher = ServiceLocator.Instance.GetService<IEventDispatcher>();
        }
        public void Move(ProjectileEntity projectile)
        {
            var speed = projectile.Speed * Time.deltaTime;
            projectile.Position = Vector3.MoveTowards(projectile.Position, projectile.TargetPosition, speed);
            
            
            _eventDispatcher.Dispatch(new ProjectilesMoved(projectile.InstanceId, projectile.Position));
        }
    }
}