using System;
using UnityEngine;

namespace Core.Turrets.Views
{
    public class ProjectileView : GameView
    {
        public Action<int> CollidedWithCreep;

        private void OnTriggerEnter(Collider other)
        {
            var creepView = other.gameObject.GetComponent<CreepView>();
            CollidedWithCreep?.Invoke(creepView.GetInstanceID());
        }
    }
}