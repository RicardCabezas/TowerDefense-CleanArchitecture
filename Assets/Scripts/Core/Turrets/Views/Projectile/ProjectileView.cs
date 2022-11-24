using System;
using Core.Creeps.Views;
using Pool.BaseObjectRepresentation;
using UnityEngine;

namespace Core.Turrets.Views.Projectile
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