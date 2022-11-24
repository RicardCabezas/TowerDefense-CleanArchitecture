using Core.LevelFinished.Events;
using Events;
using UnityEngine;

namespace Core.LevelFinished.UseCases
{
    public class LevelCompletedUseCase
    {
        private readonly LevelFinishedRepository _repository;
        private readonly AssetCatalog.AssetCatalog _assetCatalog;
        private readonly IEventDispatcher _eventDispatcher;

        public LevelCompletedUseCase(LevelFinishedRepository repository)
        {
            _repository = repository;
            _eventDispatcher = ServiceLocator.Instance.GetService<IEventDispatcher>();
        }

        public void ShowLevelCompletedScreen()
        {
            Time.timeScale = 0; //Stop gameplay

            _repository.CreateLevelCompletedScreen();
            _eventDispatcher.Dispatch(new LevelCompletedScreenCreatedEvent());
        }
    }
}