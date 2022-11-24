using Events;

namespace Core.Turrets.Events
{
    public struct CreepEnteredTurretRange : BaseEvent
    {
        public int TurretInstanceId { get; }
        public int CreepInstanceId { get; }
        
        public CreepEnteredTurretRange(int creepInstanceId, int turretInstanceId)
        {
            CreepInstanceId = creepInstanceId;
            TurretInstanceId = turretInstanceId;
        }
    }
}