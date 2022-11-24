using Core.Base;
using Core.LevelFinished.Events;
using Core.LevelFinished.Views;
using Events;
using UnityEngine;

namespace Core.LevelFinished.UseCases
{
    public class LevelFailedUseCase
    {
        private readonly LevelFinishedRepository _repository;
        private readonly AssetCatalog.AssetCatalog _assetCatalog;
        private readonly IEventDispatcher _eventDispatcher;

        public LevelFailedUseCase(LevelFinishedRepository repository)
        {
            _repository = repository;
            _eventDispatcher = ServiceLocator.Instance.GetService<IEventDispatcher>();
            
            _eventDispatcher.Subscribe<BaseCampDestroyedEvent>(OnBaseCampDestroyed);     //TODO: move to controller        
        }

        private void OnBaseCampDestroyed(BaseCampDestroyedEvent obj)
        {
            ShowLevelFailScreen();
        }

        public void ShowLevelFailScreen()
        {
            _repository.CreateLevelFailedScreen();

            _eventDispatcher.Dispatch(
                new LevelFailedScreenCreatedEvent()); //TODO: subscribe time controller to set time scale to 0
            _eventDispatcher.Unsubscribe<BaseCampDestroyedEvent>(OnBaseCampDestroyed);
            
            Time.timeScale = 0; //Stop gameplay
        }
    }
}