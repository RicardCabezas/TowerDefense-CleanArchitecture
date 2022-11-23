using Core.Turrets.UseCases;

namespace Core.Turrets.Views
{
    public class ShootingTurret
    {
        public ITurretShoot ShootUseCase;
        public float TurretShootCooldown; //TODO: replace with datetime
        public float TimeSinceLastShot;
    }
}