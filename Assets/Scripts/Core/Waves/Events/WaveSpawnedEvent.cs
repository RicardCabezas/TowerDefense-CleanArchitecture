using Events;

namespace Core.Waves.Events
{
    public struct WaveSpawnedEvent : BaseEvent
    {
        public int Wave { get; }

        public WaveSpawnedEvent(int wave)
        {
            Wave = wave;
        }
    }
}