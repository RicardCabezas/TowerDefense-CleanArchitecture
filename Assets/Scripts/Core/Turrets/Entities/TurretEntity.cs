using UnityEngine;

namespace Core.Turrets.Entities
{
    public class TurretEntity //TODO: create frozen turret entity, etc
    {
        public CreepEntity Target;
        public string ProjectileId;
        public float TurretShootCooldown; //TODO: replace with datetime
        public float TimeSinceLastShot;
        public Vector3 Position;
    }
}