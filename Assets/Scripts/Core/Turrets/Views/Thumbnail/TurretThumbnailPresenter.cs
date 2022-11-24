using System.Globalization;
using Core.Turrets.Events;
using Events;
using Pool.BaseObjectRepresentation;

namespace Core.Turrets.Views.Thumbnail
{
    public class TurretThumbnailPresenter : BasePresenter
    {
        private TurretThumbnailView _view;
        private IEventDispatcher _eventDispatcher;

        public TurretThumbnailPresenter(TurretThumbnailView view)
        {
            _view = view;
            
            _eventDispatcher = ServiceLocator.ServiceLocator.Instance.GetService<IEventDispatcher>();
            _eventDispatcher.Subscribe<TurretSelectorSpawned>(OnTurretSelectorSpawned);

            _view.Dispose += OnViewDisposed;
        }

        private void OnViewDisposed()
        {
            _eventDispatcher.Unsubscribe<TurretSelectorSpawned>(OnTurretSelectorSpawned);
            
            _eventDispatcher = null;
            _view = null;
        }

        private void OnTurretSelectorSpawned(TurretSelectorSpawned eventInfo)
        {
            var turret = eventInfo.Turret;

            _view.Price.text = turret.Cost.ToString(CultureInfo.InvariantCulture);
            _view.Button.image.color = turret.ThumbnailColor;

            _eventDispatcher.Unsubscribe<TurretSelectorSpawned>(OnTurretSelectorSpawned);
        }
    }
}