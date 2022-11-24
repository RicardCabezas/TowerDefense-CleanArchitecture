using Core.Turrets.UseCases;

namespace Core.Turrets.Views
{
    public class ShootingTurret
    {
        public ITurretShootUseCase ShootUseCaseUseCase;
        public float TurretShootCooldown; //TODO: replace with datetime
        public float TimeSinceLastShot;
    }
}