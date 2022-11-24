using Core.Turrets.Events;
using Events;

namespace Core.Turrets.Views
{
    public class ProjectilePresenter : BasePresenter
    {
        private readonly ProjectileView _view;
        private readonly IEventDispatcher _eventDispatcher;

        public ProjectilePresenter(ProjectileView view)
        {
            _view = view;
            
            _eventDispatcher = ServiceLocator.Instance.GetService<IEventDispatcher>();
        
            _eventDispatcher.Subscribe<ProjectilesMoved>(OnProjectilesMoved);
        }

        private void OnProjectilesMoved(ProjectilesMoved eventInfo) //TODO: move outside
        {
            if (_view.GetInstanceID() == eventInfo.ProjectileInstanceId)
            {
                _view.transform.position = eventInfo.NewPosition;
            }
        }
    }
}