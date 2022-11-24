using System.Globalization;
using Core.Turrets.Events;
using Events;

namespace Core.Turrets.Views
{
    public class TurretThumbnailPresenter : BasePresenter
    {
        private TurretThumbnailView _view;
        private IEventDispatcher _eventDispatcher;

        public TurretThumbnailPresenter(TurretThumbnailView view)
        {
            _view = view;
            
            _eventDispatcher = ServiceLocator.Instance.GetService<IEventDispatcher>();
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
        }
        
        //TODO: create thumbnail Entity that store the Instance ID
        //TODO: react to money spent and disable button
        //TODO: create Thumbnail PresenterContainer
    }
}