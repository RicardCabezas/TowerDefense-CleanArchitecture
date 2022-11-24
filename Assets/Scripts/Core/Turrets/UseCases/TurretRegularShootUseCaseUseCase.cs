using Core.Turrets.Entities;

namespace Core.Turrets.UseCases
{
    public class TurretRegularShootUseCaseUseCase : ITurretShootUseCase
    {
        private readonly TurretsRepository _repository;

        public TurretRegularShootUseCaseUseCase(TurretsRepository repository)
        {
            _repository = repository;
        }
        public void Shoot()
        {
            //TODO: call projectile factory to decide which projectile do I need to use
        }
    }
    
    public class FrozenTurretShootUseCaseUseCase : ITurretShootUseCase
    {
        public void Shoot()
        {
            
        }
    }
}