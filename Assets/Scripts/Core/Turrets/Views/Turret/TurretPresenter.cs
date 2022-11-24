using Core.Turrets.Events;
using Events;
using UnityEngine;

namespace Core.Turrets.Views
{
    public class TurretPresenter : BasePresenter
    {
        private TurretView _view;
        private IEventDispatcher _eventDispatcher;

        public TurretPresenter(TurretView view)
        {
            _view = view;
            
            _eventDispatcher = ServiceLocator.Instance.GetService<IEventDispatcher>();
            _eventDispatcher.Subscribe<TurretSelectorSpawned>(OnTurretSelectorSpawned); //TODO: subscribe to turret spawned

            _view.Dispose += OnViewDisposed;
        }

        public void UpdatePosition(Vector3 position)
        {
            _view.transform.position = position;
        }

        private void OnTurretSelectorSpawned(TurretSelectorSpawned eventInfo)
        {
            _view.gameObject.SetActive(true);
        }
        
        private void OnViewDisposed()
        {
            _eventDispatcher.Unsubscribe<TurretSelectorSpawned>(OnTurretSelectorSpawned);
            
            _eventDispatcher = null;
            _view = null;
        }
    }
}