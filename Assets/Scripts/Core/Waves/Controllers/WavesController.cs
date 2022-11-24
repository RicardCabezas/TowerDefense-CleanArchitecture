using Core.Base;
using Events;

namespace Core.Waves.Controllers
{
    public class WavesController
    {
        private readonly UpdateWaveUseCase _updateWaveUseCase;
        private readonly IEventDispatcher _eventDispatcher;
        private readonly WavesRepository _wavesRepository;

        public WavesController(UpdateWaveUseCase updateWaveUseCase)
        {
            _updateWaveUseCase = updateWaveUseCase;
            _eventDispatcher = ServiceLocator.Instance.GetService<IEventDispatcher>();

            _eventDispatcher.Subscribe<CreepDestroyedEvent>(OnCreepDestroyed);
        }

        private void OnCreepDestroyed(CreepDestroyedEvent obj)
        {
            _updateWaveUseCase.UpdateWave();
        }
    }
}