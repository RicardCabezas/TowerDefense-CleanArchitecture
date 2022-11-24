using Events;
using Pool.BaseObjectRepresentation;

namespace Core.SpawnerPoints.Views
{
    public class SpawnerPresenter : BasePresenter //TODO: remove?
    {
        private readonly SpawnerView _view;
        private readonly IEventDispatcher _eventDispatcher;

        //TODO: dispose when view destroyed

        public SpawnerPresenter(SpawnerView view)
        {
        }
    }
}