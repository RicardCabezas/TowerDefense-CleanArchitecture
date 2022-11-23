using System;
using System.Collections.Generic;
using Core.Turrets.Configs;
using Core.Turrets.Entities;
using Core.Turrets.UseCases;
using Core.Turrets.Views;
using UnityEngine;

public class TurretsInstaller : MonoBehaviour
{
    public LocalTurretsConfig TurretsLocalConfig;
    public Transform ThumnailTurretsParent;

    public void Install()
    {
        var turretsRepository = new TurretsRepository(TurretsLocalConfig.TurretsConfig, ThumnailTurretsParent);

        var spawnTurretThumbnailsUseCase = new SpawnTurretSelectorUseCase();

        var turretShootingController = new TurretShootingController(turretsRepository);
        spawnTurretThumbnailsUseCase.Spawn(turretsRepository, TurretsLocalConfig.TurretsConfig);
    }
}