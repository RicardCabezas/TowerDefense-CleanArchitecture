using Core.Waves.Entity;
using Core.Waves.Events;
using Events;

namespace Core.Waves.UseCase
{
    public class UpdateWaveUseCase
    {
        private readonly WavesRepository _wavesRepository;
        private readonly SpawnWaveUseCase _spawnWaveUseCase;
        private readonly IEventDispatcher _eventDispatcher;

        public UpdateWaveUseCase(WavesRepository wavesRepository, SpawnWaveUseCase spawnWaveUseCase)
        {
            _wavesRepository = wavesRepository;
            _spawnWaveUseCase = spawnWaveUseCase;
        
            _eventDispatcher = ServiceLocator.ServiceLocator.Instance.GetService<IEventDispatcher>();
        }

        public void UpdateWave()
        {
            var remainingCreeps = _wavesRepository.DecreaseRemainingCreeps();

            if (remainingCreeps <= 0)
            {
                if (!_wavesRepository.IsLastWave())
                {
                    _wavesRepository.UpdateCurrentWave();
                    _spawnWaveUseCase.SpawnCreepsInWave();
                    _wavesRepository.ResetRemainingCreeps();
                }
            }

            var updateRemainingCreeps = _wavesRepository.GetRemainingCreeps();
            var waveIndex = _wavesRepository.GetCurrentWaveIndex();
            _eventDispatcher.Dispatch(new WaveUpdatedEvent(waveIndex, remainingCreeps));
        }
    }
}