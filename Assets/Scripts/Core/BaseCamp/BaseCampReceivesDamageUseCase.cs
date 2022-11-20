using Core.LevelFinished;
using ScreenMachine;
using States;

namespace Core.Base
{
    public class BaseCampReceivesDamageUseCase
    {
        private readonly BaseCampRepository _baseCampRepository;
        private readonly ScreenMachineImplementation _screenMachine;
        private readonly LevelFinishedRepository _levelFinishedRepository;

        public BaseCampReceivesDamageUseCase(
            BaseCampRepository baseCampRepository,
            ScreenMachineImplementation screenMachine,
            LevelFinishedRepository levelFinishedRepository)
        {
            _baseCampRepository = baseCampRepository;
            _screenMachine = screenMachine;
            _levelFinishedRepository = levelFinishedRepository;
        }
        void ReceiveDamage(float damage) //TODO: subscribe to enemy dmg event
        { 
            _baseCampRepository.UpdateBaseHealth(damage);
            
            if (_baseCampRepository.GetBaseHealth() <= 0)
            {
                _screenMachine.PushState(new LevelFailState(_levelFinishedRepository));
            }
        }
    }
}