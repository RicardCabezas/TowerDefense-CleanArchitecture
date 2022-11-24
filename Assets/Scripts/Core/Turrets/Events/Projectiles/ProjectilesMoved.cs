using Events;
using UnityEngine;

namespace Core.Turrets.Events
{
    public struct ProjectilesMoved : BaseEvent
    {
        public int ProjectileInstanceId { get; }
        public Vector3 NewPosition { get; }

        public ProjectilesMoved(int instanceId, Vector3 newPosition)
        {
            ProjectileInstanceId = instanceId;
            NewPosition = newPosition;
        }
    }
}