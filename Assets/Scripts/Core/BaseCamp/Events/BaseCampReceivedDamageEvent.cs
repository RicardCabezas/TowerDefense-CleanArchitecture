using Events;

namespace Core.Base
{
    public struct BaseCampReceivedDamageEvent : BaseEvent //TODO: change by creep attacked event
    {
        public float Damage { get; }

        public BaseCampReceivedDamageEvent(float damage)
        {
            Damage = damage;
        }
    }
}