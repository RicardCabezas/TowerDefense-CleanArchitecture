using Core.BaseCamp.Entities;
using Core.BaseCamp.Events;
using Core.LevelFinished.LevelFinishedRepository;
using Events;

namespace Core.BaseCamp.UseCases
{
    public class BaseCampReceivesDamageUseCase
    {
        private readonly BaseCampRepository _baseCampRepository;
        private readonly IEventDispatcher _eventDispatcher;
        private readonly LevelFinishedRepository _levelFinishedRepository;

        public BaseCampReceivesDamageUseCase(BaseCampRepository baseCampRepository,
            LevelFinishedRepository levelFinishedRepository)
        {
            _baseCampRepository = baseCampRepository;
            _eventDispatcher = ServiceLocator.ServiceLocator.Instance.GetService<IEventDispatcher>();
            _levelFinishedRepository = levelFinishedRepository;
        }

        public void ReceiveDamage(float damage)
        {
            _baseCampRepository.UpdateBaseHealth(damage);

            if (_baseCampRepository.GetBaseHealth() <= 0)
            {
                _eventDispatcher.Dispatch(new BaseCampDestroyedEvent());
            }
        }
    }
}