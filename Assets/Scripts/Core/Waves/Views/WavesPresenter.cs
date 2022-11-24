using System;
using Core.Waves.Events;
using Events;
using Object = UnityEngine.Object;

namespace Core.Waves
{
    public class WavesPresenter : BasePresenter
    {
        private WavesView _view;
        private IEventDispatcher _eventDispatcher;

        public WavesPresenter(WavesView view)
        {
            _view = view;

            _eventDispatcher = ServiceLocator.Instance.GetService<IEventDispatcher>();
        
            _eventDispatcher.Subscribe<WaveSpawnedEvent>(OnWaveSpawned);

            _view.Dispose += OnViewDisposed;
        }

        private void OnWaveSpawned(WaveSpawnedEvent eventInfo)
        {
            _view.CurrentWave.text = (eventInfo.Wave + 1).ToString();
        }
        
        private void OnViewDisposed()
        {
            _eventDispatcher.Unsubscribe<WaveSpawnedEvent>(OnWaveSpawned);

            _view = null;
            _eventDispatcher = null;
        }
    }
}