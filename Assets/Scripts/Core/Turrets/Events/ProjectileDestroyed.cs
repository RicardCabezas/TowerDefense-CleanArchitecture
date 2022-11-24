using Core.Turrets.Entities;
using Events;

namespace Core.Turrets.Events
{
    public struct ProjectileDestroyed : BaseEvent
    {
        public ProjectileEntity Projectile { get; }

        public ProjectileDestroyed(ProjectileEntity projectile)
        {
            Projectile = projectile;
        }
    }
}