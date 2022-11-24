using UnityEngine;

namespace Core.Turrets.Entities
{
    public class TurretEntity
    {
        public CreepEntity Target;
        public string ProjectileId;
        public float TurretShootCooldown;
        public float TimeSinceLastShot;
        public Vector3 Position;
        public int Cost;
    }
}