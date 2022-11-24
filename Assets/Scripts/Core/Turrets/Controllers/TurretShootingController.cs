using System.Collections.Generic;
using System.Linq;
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
        List<TurretEntity> _turretsShooting = new List<TurretEntity>();
        private readonly IEventDispatcher _eventDispatcher;
        private readonly TurretShootUseCaseUse _shootUseCase;

        public TurretShootingController(TurretsRepository repository, ProjectilesRepository projectilesRepository)
        {
            _repository = repository;
            _eventDispatcher = ServiceLocator.Instance.GetService<IEventDispatcher>();
            
            _eventDispatcher.Subscribe<TurretTargetUpdated>(OnTargetUpdated);
            _eventDispatcher.Subscribe<CreepDestroyedEvent>(OnCreepDestroyed);

            _shootUseCase = new TurretShootUseCaseUse(projectilesRepository);
        }

        private void OnCreepDestroyed(CreepDestroyedEvent eventInfo)
        {
            _turretsShooting.RemoveAll(activeTurrets => activeTurrets.Target == eventInfo.Creep);
        }

        private void OnTargetUpdated(TurretTargetUpdated eventInfo)
        {
            //TODO: create ShootingTurretUseCaseFactory ->
            _turretsShooting.Add(eventInfo.Turret);
        }


        public void Update() //TODO: call from installer
        {
            foreach (var turret in _turretsShooting)
            {
                if (turret.TimeSinceLastShot >= turret.TurretShootCooldown)
                {
                    _shootUseCase.Shoot(turret);
                    turret.TimeSinceLastShot = 0;
                }
                
                turret.TimeSinceLastShot += Time.deltaTime;
            }
        }
    }
}