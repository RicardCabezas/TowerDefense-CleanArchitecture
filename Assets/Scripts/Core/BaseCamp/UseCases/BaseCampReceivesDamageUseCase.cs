using Core.LevelFinished;
using Events;

namespace Core.Base
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
            _eventDispatcher = ServiceLocator.Instance.GetService<IEventDispatcher>();
            _levelFinishedRepository = levelFinishedRepository;
            
            _eventDispatcher.Subscribe<BaseCampReceivedDamageEvent>(OnBaseCampReceivesDamage);
        }

        private void OnBaseCampReceivesDamage(BaseCampReceivedDamageEvent damageReceivedEvent)
        {
            _baseCampRepository.UpdateBaseHealth(damageReceivedEvent.Damage);
            //TODO: fire event updating health

            if (_baseCampRepository.GetBaseHealth() <= 0)
            {
                //TODO: call level fail
                //_screenMachine.PushState(new LevelFailState(_levelFinishedRepository));
            }
        }
    }
}