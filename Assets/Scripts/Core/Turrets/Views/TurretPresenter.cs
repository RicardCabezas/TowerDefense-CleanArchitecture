using Core.Turrets.Events;
using Events;

namespace Core.Turrets.Views
{
    public class TurretPresenter
    {
        private readonly TurretView _view;
        private readonly IEventDispatcher _eventDispatcher;

        public TurretPresenter(TurretView view)
        {
            _view = view;
            
            _eventDispatcher = ServiceLocator.Instance.GetService<IEventDispatcher>();
            _eventDispatcher.Subscribe<TurretSelectorSpawned>(OnTurretSelectorSpawned); //TODO: subscribe to turret spawned
            
        }

        private void OnTurretSelectorSpawned(TurretSelectorSpawned eventInfo)
        {
            _view.gameObject.SetActive(true);
            
        }
    }
}