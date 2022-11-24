using System;
using System.Collections.Generic;
using Core.Creeps.Controllers;
using Events;
using UnityEngine;

public class CreepsInstaller : MonoBehaviour
{
    public LocalCreepsConfig CreepsLocalConfig;
    public LevelSpawnerPointsLocalConfig SpawnerPointsConfig;
    public Transform UserBasePosition;
    private MovingCreepsController _movingCreepsController;

    public void Install()
    {
        var serviceLocator = ServiceLocator.Instance;
        
        var creepRepository = new CreepRepository(CreepsLocalConfig.CreepsConfig);
        serviceLocator.RegisterService(creepRepository);
        
        var spawnerPointsRepository = new SpawnerPointsRepository(SpawnerPointsConfig.Spawners);
        serviceLocator.RegisterService(spawnerPointsRepository);
        
        var moveCreepsUseCase = new MoveCreepsUseCase(creepRepository, UserBasePosition);
        _movingCreepsController = new MovingCreepsController(moveCreepsUseCase);
    }

    private void Update()
    {
        _movingCreepsController.Update();
    }
}