using Core.Waves.Events;
using Events;

namespace Core.Waves
{
    public class WavesPresenter
    {
        private readonly WavesView _view;
        private readonly IEventDispatcher _eventDispatcher;

        //TODO: dispose when view destroyed
        public WavesPresenter(WavesView view)
        {
            _view = view;

            _eventDispatcher = ServiceLocator.Instance.GetService<IEventDispatcher>();
        
            _eventDispatcher.Subscribe<WaveSpawnedEvent>(OnWaveSpawned);
        }

        private void OnWaveSpawned(WaveSpawnedEvent eventInfo)
        {
            _view.CurrentWave.text = (eventInfo.Wave + 1).ToString();
        }
    }
}