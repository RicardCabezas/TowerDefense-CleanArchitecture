using Core.LevelFinished.Events;
using Events;

namespace Core.LevelFinished.Views
{
    public class LevelCompletedPresenter : BasePresenter
    {
        private LevelCompletedView _view;
        private IEventDispatcher _eventDispatcher;

        public LevelCompletedPresenter(LevelCompletedView view)
        {
            _view = view;
            _view.gameObject.SetActive(false);
            _eventDispatcher = ServiceLocator.Instance.GetService<IEventDispatcher>();
            
            _eventDispatcher.Subscribe<LevelCompletedScreenCreatedEvent>(OnLevelCompleteScreenCreated);   
            
            _view.Dispose += OnViewDisposed;
        }

        private void OnLevelCompleteScreenCreated(LevelCompletedScreenCreatedEvent obj)
        {
            _view.gameObject.SetActive(true);
        }
        
        private void OnViewDisposed()
        {
            _eventDispatcher.Unsubscribe<LevelCompletedScreenCreatedEvent>(OnLevelCompleteScreenCreated);   
            
            _eventDispatcher = null;
            _view = null;
        }
    }
}