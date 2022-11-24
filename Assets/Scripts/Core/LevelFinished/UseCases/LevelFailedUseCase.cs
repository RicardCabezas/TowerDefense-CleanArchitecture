using Core.LevelFinished.Events;
using Events;
using UnityEngine;

namespace Core.LevelFinished.UseCases
{
    public class LevelFailedUseCase
    {
        private readonly LevelFinishedRepository.LevelFinishedRepository _repository;
        private readonly AssetCatalog.AssetCatalog _assetCatalog;
        private readonly IEventDispatcher _eventDispatcher;

        public LevelFailedUseCase(LevelFinishedRepository.LevelFinishedRepository repository)
        {
            _repository = repository;
            _eventDispatcher = ServiceLocator.ServiceLocator.Instance.GetService<IEventDispatcher>();
        }

        public void ShowLevelFailScreen()
        {
            Time.timeScale = 0; //Stop gameplay

            _repository.CreateLevelFailedScreen();
            _eventDispatcher.Dispatch(new LevelFailedScreenCreatedEvent());
        }
    }
}