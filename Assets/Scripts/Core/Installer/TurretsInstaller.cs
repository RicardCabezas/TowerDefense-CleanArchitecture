using System;
using System.Collections.Generic;
using Core.Turrets.Configs;
using Core.Turrets.Entities;
using Core.Turrets.UseCases;
using Core.Turrets.Views;
using Events;
using UnityEngine;

public class TurretsInstaller : MonoBehaviour
{
    public LocalTurretsConfig TurretsLocalConfig;
    public Transform ThumnailTurretsParent;
    public TurretSpawnerPreviewerController SpawnerPreviewerController;
    private TurretShootingController _turretShootingController;
    private MovingProjectilesController _projectilesMovingController;

    public void Install(CreepRepository creepRepository)
    {
        var turretsRepository = new TurretsRepository(TurretsLocalConfig.TurretsConfig, ThumnailTurretsParent);
        ServiceLocator.Instance.RegisterService(turretsRepository);

        var spawnTurretThumbnailsUseCase = new SpawnTurretSelectorUseCase();

        var updateTurretTargetUseCase = new UpdateTurretTargetUseCase(creepRepository, turretsRepository); 
        var updateTurretTargetController = new UpdateTurretTargetController(updateTurretTargetUseCase);
        
        _turretShootingController = new TurretShootingController(turretsRepository);
        _projectilesMovingController = new MovingProjectilesController();
        spawnTurretThumbnailsUseCase.Spawn(turretsRepository, TurretsLocalConfig.TurretsConfig, SpawnerPreviewerController);
    }

    private void Update()
    {
        _turretShootingController.Update();
        _projectilesMovingController.Update();
    }
}