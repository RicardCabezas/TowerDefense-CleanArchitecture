using Core.Turrets.Events;
using Events;
using UnityEngine;

namespace Core.Turrets.Views
{
    public class TurretPresenter
    {
        private readonly TurretView _view;
        private readonly IEventDispatcher _eventDispatcher;

        public TurretPresenter(TurretView view, Vector3 position)
        {
            _view = view;
            
            _eventDispatcher = ServiceLocator.Instance.GetService<IEventDispatcher>();
            _eventDispatcher.Subscribe<TurretSelectorSpawned>(OnTurretSelectorSpawned); //TODO: subscribe to turret spawned


            _view.transform.position = position;
        }

        private void OnTurretSelectorSpawned(TurretSelectorSpawned eventInfo)
        {
            _view.gameObject.SetActive(true);
        }
    }
}