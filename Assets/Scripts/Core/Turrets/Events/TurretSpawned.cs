using Core.Turrets.Configs;
using Events;

namespace Core.Turrets.Events
{
    public struct TurretSpawned : BaseEvent
    {
        public TurretConfig Turret { get; }

        public TurretSpawned(TurretConfig turret)
        {
            Turret = turret;
        }
    }
}