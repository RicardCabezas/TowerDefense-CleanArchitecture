using Core.Turrets.Configs;
using Events;

namespace Core.Turrets.Events
{
    public struct TurretSelectorSpawned : BaseEvent
    {
        public TurretConfig Turret { get; }

        public TurretSelectorSpawned(TurretConfig turret)
        {
            Turret = turret;
        }
    }
}