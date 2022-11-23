using System.Globalization;
using Core.Turrets.Events;
using Events;

namespace Core.Turrets.Views
{
    public class TurretThumbnailPresenter
    {
        private readonly TurretThumbnailView _view;
        private readonly IEventDispatcher _eventDispatcher;

        public TurretThumbnailPresenter(TurretThumbnailView view)
        {
            _view = view;
            
            _eventDispatcher = ServiceLocator.Instance.GetService<IEventDispatcher>();
            _eventDispatcher.Subscribe<TurretSelectorSpawned>(OnTurretSelectorSpawned);}

        private void OnTurretSelectorSpawned(TurretSelectorSpawned eventInfo)
        {
            var turret = eventInfo.Turret;

            _view.Price = turret.Cost.ToString(CultureInfo.InvariantCulture);
            
            _view.Button.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            //TODO: send event of turret clicked
            throw new System.NotImplementedException();
        }
    }
}