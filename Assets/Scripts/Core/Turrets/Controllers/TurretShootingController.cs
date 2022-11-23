using System.Collections.Generic;
using Core.Turrets.Entities;
using Core.Turrets.Events;
using Core.Turrets.UseCases;
using Events;
using UnityEngine;

namespace Core.Turrets.Views
{
    public class TurretShootingController
    {
        private readonly TurretsRepository _repository;
        List<ShootingTurret> _turretShoots = new List<ShootingTurret>();
        private readonly IEventDispatcher _eventDispatcher;

        public TurretShootingController(TurretsRepository repository)
        {
            _repository = repository;
            _eventDispatcher = ServiceLocator.Instance.GetService<IEventDispatcher>();
            _eventDispatcher.Subscribe<TurretSpawned>(OnTurretSpawned);
        }

        private void OnTurretSpawned(TurretSpawned eventInfo)
        {
            //TODO: create ShootingTurretUseCaseFactory ->
            var shootingTurret = new ShootingTurret()
            {
                ShootUseCase = new TurretRegularShootUseCase(_repository),
                TimeSinceLastShot = 0f,
                TurretShootCooldown = eventInfo.Turret.Cooldown
            };
            
            _turretShoots.Add(shootingTurret);
        }

        public void Update() //TODO: call from installer
        {
            foreach (var turret in _turretShoots)
            {
                if (turret.TimeSinceLastShot >= turret.TurretShootCooldown)
                {
                    turret.ShootUseCase.Shoot();
                    turret.TimeSinceLastShot = 0;
                }
                
                turret.TimeSinceLastShot += Time.deltaTime;
            }
        }
    }
}