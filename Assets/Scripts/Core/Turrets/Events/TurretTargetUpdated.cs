using Core.Turrets.Entities;
using Events;

namespace Core.Turrets.Events
{
    public struct TurretTargetUpdated : BaseEvent
    {
        public TurretEntity Turret { get; }

        public TurretTargetUpdated(TurretEntity turret)
        {
            Turret = turret;
        }
    }
}