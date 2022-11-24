using Core.Turrets.Events;
using Events;

namespace Core.Turrets.Views
{
    public class ProjectilePresenter : BasePresenter
    {
        private ProjectileView _view;
        private IEventDispatcher _eventDispatcher;

        public ProjectilePresenter(ProjectileView view)
        {
            _view = view;
            
            _eventDispatcher = ServiceLocator.Instance.GetService<IEventDispatcher>();
        
            _eventDispatcher.Subscribe<ProjectilesMoved>(OnProjectilesMoved);
            
            _view.Dispose += OnViewDisposed;
        }

        private void OnProjectilesMoved(ProjectilesMoved eventInfo) //TODO: move outside
        {
            if (_view.GetInstanceID() == eventInfo.ProjectileInstanceId)
            {
                _view.transform.position = eventInfo.NewPosition;
            }
        }
        
        private void OnViewDisposed()
        {
            _eventDispatcher.Unsubscribe<ProjectilesMoved>(OnProjectilesMoved);
            
            _eventDispatcher = null;
            _view = null;
        }
    }
}