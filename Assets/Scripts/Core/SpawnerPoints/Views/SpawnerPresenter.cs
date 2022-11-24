using Events;

namespace Core.SpawnerPoints.Views
{
    public class SpawnerPresenter : BasePresenter
    {
        private readonly SpawnerView _view;
        private readonly IEventDispatcher _eventDispatcher;

        //TODO: dispose when view destroyed

        public SpawnerPresenter(SpawnerView view)
        {
            _view = view;

            _eventDispatcher = ServiceLocator.Instance.GetService<IEventDispatcher>();
        }
    }
}