using Core.BaseCamp.Events;
using Core.Creeps.Events;
using Core.LevelFinished.UseCases;
using Core.Waves.Entity;
using Events;

namespace Core.LevelFinished.Controllers
{
    public class LevelFinishedController
    {
        private readonly LevelFailedUseCase _levelFailedUseCase;
        private readonly LevelCompletedUseCase _levelCompletedUseCase;
        private readonly IEventDispatcher _eventDispatcher;
        private readonly WavesRepository _wavesRepository;

        public LevelFinishedController(LevelFailedUseCase levelFailedUseCase,
            LevelCompletedUseCase levelCompletedUseCase)
        {
            _levelFailedUseCase = levelFailedUseCase;
            _levelCompletedUseCase = levelCompletedUseCase;
            
            _eventDispatcher = ServiceLocator.ServiceLocator.Instance.GetService<IEventDispatcher>();
            _wavesRepository = ServiceLocator.ServiceLocator.Instance.GetService<WavesRepository>();

            _eventDispatcher.Subscribe<BaseCampDestroyedEvent>(OnBaseCampDestroyed);
            
            _eventDispatcher.Subscribe<CreepDestroyedEvent>(OnCreepDestroyed);

        }

        private void OnCreepDestroyed(CreepDestroyedEvent obj)
        {
            if (_wavesRepository.IsLastWave() && _wavesRepository.IsWaveCompleted())
            {
                _levelCompletedUseCase.ShowLevelCompletedScreen();
            }
        }

        private void OnBaseCampDestroyed(BaseCampDestroyedEvent eventInfo)
        {
            _eventDispatcher.Unsubscribe<BaseCampDestroyedEvent>(OnBaseCampDestroyed);
            
            _levelFailedUseCase.ShowLevelFailScreen();
        }
    }
}