using Core.LevelFinished.Events;
using Events;
using Pool.BaseObjectRepresentation;

namespace Core.LevelFinished.Views
{
    public class LevelFailedPresenter : BasePresenter
    {
        private LevelFailedView _view;
        private IEventDispatcher _eventDispatcher;

        public LevelFailedPresenter(LevelFailedView view)
        {
            _view = view;
            _view.gameObject.SetActive(false);
            _eventDispatcher = ServiceLocator.ServiceLocator.Instance.GetService<IEventDispatcher>();
            
            _eventDispatcher.Subscribe<LevelFailedScreenCreatedEvent>(OnLevelFailedScreenCreated);   
            
            _view.Dispose += OnViewDisposed;
        }

        private void OnLevelFailedScreenCreated(LevelFailedScreenCreatedEvent obj)
        {
            _view.gameObject.SetActive(true);
        }
        
        private void OnViewDisposed()
        {
            _eventDispatcher.Unsubscribe<LevelFailedScreenCreatedEvent>(OnLevelFailedScreenCreated);   
            
            _eventDispatcher = null;
            _view = null;
        }
    }
}