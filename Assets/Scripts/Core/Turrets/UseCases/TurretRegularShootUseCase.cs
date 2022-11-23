using Core.Turrets.Entities;

namespace Core.Turrets.UseCases
{
    public class TurretRegularShootUseCase : ITurretShoot
    {
        private readonly TurretsRepository _repository;

        public TurretRegularShootUseCase(TurretsRepository repository)
        {
            _repository = repository;
        }
        public void Shoot()
        {
            //TODO: call projectile factory to decide which projectile do I need to use
        }
    }
    
    public class FrozenTurretShootUseCase : ITurretShoot
    {
        public void Shoot()
        {
            
        }
    }
}