using Core.LevelFinished;
using Events;
using ScreenMachine;
using States;

namespace Core.Base
{
    public class BaseCampReceivesDamageUseCase
    {
        private readonly BaseCampRepository _baseCampRepository;
        private readonly ScreenMachineImplementation _screenMachine;
        private readonly IEventDispatcher _eventDispatcher;
        private readonly LevelFinishedRepository _levelFinishedRepository;

        public BaseCampReceivesDamageUseCase(BaseCampRepository baseCampRepository,
            LevelFinishedRepository levelFinishedRepository,
            ScreenMachineImplementation screenMachine)
        {
            _baseCampRepository = baseCampRepository;
            _screenMachine = screenMachine;
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
                _screenMachine.PushState(new LevelFailState(_levelFinishedRepository));
            }
        }
    }
}