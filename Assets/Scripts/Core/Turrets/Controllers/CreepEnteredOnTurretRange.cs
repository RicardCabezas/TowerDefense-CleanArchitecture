using Core.Creeps.Views;
using Core.Turrets.Events;
using Core.Turrets.Views.Turret;
using Events;
using UnityEngine;

namespace Core.Turrets.Controllers
{
    public class CreepEnteredOnTurretRange : MonoBehaviour
    {
        [SerializeField] private TurretView _turretView;
        private IEventDispatcher _eventDispatcher;

        private void Start()
        {
            _eventDispatcher = ServiceLocator.ServiceLocator.Instance.GetService<IEventDispatcher>();
        }

        private void OnTriggerEnter(Collider other)
        {
            var creepView = other.gameObject.GetComponent<CreepView>();
            _eventDispatcher.Dispatch(new CreepEnteredTurretRange(creepView.GetInstanceID(), _turretView.GetInstanceID()));
        }
    }
}