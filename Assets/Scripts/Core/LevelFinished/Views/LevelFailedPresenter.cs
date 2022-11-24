using Core.Base;
using Core.LevelFinished.Events;
using Events;

namespace Core.LevelFinished.Views
{
    public class LevelFailedPresenter : BasePresenter
    {
        private readonly LevelFailedView _view;
        private readonly IEventDispatcher _eventDispatcher;

        public LevelFailedPresenter(LevelFailedView view)
        {
            _view = view;
            _view.gameObject.SetActive(false);
            _eventDispatcher = ServiceLocator.Instance.GetService<IEventDispatcher>();
            
            _eventDispatcher.Subscribe<LevelFailedScreenCreatedEvent>(OnLevelFailedScreenCreated);   
        }

        private void OnLevelFailedScreenCreated(LevelFailedScreenCreatedEvent obj)
        {
            _view.gameObject.SetActive(true);
        }
    }
}