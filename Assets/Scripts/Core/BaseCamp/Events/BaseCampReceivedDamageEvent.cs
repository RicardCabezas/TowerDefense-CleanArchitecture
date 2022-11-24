using Events;

namespace Core.BaseCamp.Events
{
    public struct BaseCampReceivedDamageEvent : BaseEvent
    {
        public float Damage { get; }

        public BaseCampReceivedDamageEvent(float damage)
        {
            Damage = damage;
        }
    }
}