using UnityEngine;

namespace Core.Creeps.Entities
{
    public class CreepUnit
    {
        public float CurrentHealth { get; private set; }
        public float Speed { get; private set; }

        public Vector3 Position { get; private set; }

        public Vector3 TargetPosition { get; private set; }

        public CreepUnit(CreepConfig config)
        {
            CurrentHealth = config.Health;
            Speed = config.Speed;
            Position = Vector3.zero;
            TargetPosition = Vector3.zero;
        }

        public void Move()
        {
            Position = Vector3.MoveTowards(Position, TargetPosition, Speed * Time.deltaTime);
        }
    }
}