using Events;

namespace Core.Waves.Events
{
    public struct WaveUpdatedEvent : BaseEvent
    {
        public int Wave { get; }
        public int RemainingCreeps { get; }

        public WaveUpdatedEvent(int wave, int remainingCreeps)
        {
            Wave = wave;
            RemainingCreeps = remainingCreeps;
        }
    }
}