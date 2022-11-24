using Core.Turrets.Entities;
using Events;
using UnityEngine;

namespace Core.Turrets.Events
{
    public struct ProjectilesMoved : BaseEvent //TODO: have a projectiles presenter group or whatever composition to process the event onlye once
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