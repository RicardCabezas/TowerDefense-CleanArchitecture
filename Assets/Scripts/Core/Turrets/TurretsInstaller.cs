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

    public void Install()
    {
        var serviceLocator = ServiceLocator.Instance;
        var turretsRepository = new TurretsRepository(TurretsLocalConfig.TurretsConfig, ThumnailTurretsParent);
        serviceLocator.RegisterService(turretsRepository);

        var projectilesRepository = new ProjectilesRepository(TurretsLocalConfig.TurretsConfig);
        serviceLocator.RegisterService(projectilesRepository);

        var spawnTurretThumbnailsUseCase = new SpawnTurretSelectorUseCase();

        var creepRepository = serviceLocator.GetService<CreepRepository>();
        var updateTurretTargetUseCase = new UpdateTurretTargetUseCase(creepRepository, turretsRepository); 
        var updateTurretTargetController = new UpdateTurretTargetController(updateTurretTargetUseCase);
        
        _turretShootingController = new TurretShootingController(turretsRepository, projectilesRepository);
        _projectilesMovingController = new MovingProjectilesController();
        
        spawnTurretThumbnailsUseCase.Spawn(turretsRepository, TurretsLocalConfig.TurretsConfig, SpawnerPreviewerController);
    }

    private void Update()
    {
        _turretShootingController.Update();
        _projectilesMovingController.Update();
    }
}