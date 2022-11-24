using System;
using UnityEngine;

namespace Core.Turrets.Views
{
    public class ProjectileView : MonoBehaviour
    {
        public Action<int> CollidedWithCreep;

        private void OnTriggerEnter(Collider other)
        {
            var creepView = other.gameObject.GetComponent<CreepView>();
            CollidedWithCreep?.Invoke(creepView.GetInstanceID());
        }
    }
}