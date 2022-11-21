using Events;

namespace Core.Waves.Events
{
    public class WaveSpawnedEvent : BaseEvent
    {
        public int Wave { get; }

        public WaveSpawnedEvent(int wave)
        {
            Wave = wave;
        }
    }
}