using Core.Turrets.Entities;
using Events;

namespace Core.Turrets.Events
{
    public struct TurretSpawned : BaseEvent
    {
        public TurretEntity Turret { get; }

        public TurretSpawned(TurretEntity turret)
        {
            Turret = turret;
        }
    }
}