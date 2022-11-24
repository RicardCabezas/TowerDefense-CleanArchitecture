using Core.Waves.Events;
using Events;
using Pool.BaseObjectRepresentation;

namespace Core.Waves.Views
{
    public class WavesPresenter : BasePresenter
    {
        private WavesView _view;
        private IEventDispatcher _eventDispatcher;

        public WavesPresenter(WavesView view)
        {
            _view = view;

            _eventDispatcher = ServiceLocator.ServiceLocator.Instance.GetService<IEventDispatcher>();
        
            _eventDispatcher.Subscribe<WaveUpdatedEvent>(OnWaveSpawned);

            _view.Dispose += OnViewDisposed;
        }

        private void OnWaveSpawned(WaveUpdatedEvent eventInfo)
        {
            _view.CurrentWave.text = (eventInfo.Wave + 1).ToString();
        }
        
        private void OnViewDisposed()
        {
            _eventDispatcher.Unsubscribe<WaveUpdatedEvent>(OnWaveSpawned);

            _view = null;
            _eventDispatcher = null;
        }
    }
}