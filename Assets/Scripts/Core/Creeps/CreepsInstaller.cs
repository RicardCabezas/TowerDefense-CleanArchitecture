using System;
using System.Collections.Generic;
using Events;
using UnityEngine;

public class CreepsInstaller : MonoBehaviour
{
    public LocalCreepsConfig CreepsLocalConfig;
    public LevelSpawnerPointsLocalConfig SpawnerPointsConfig;
    public Transform UserBasePosition;

    public void Install()
    {
        var serviceLocator = ServiceLocator.Instance;
        
        var creepRepository = new CreepRepository(CreepsLocalConfig.CreepsConfig);
        serviceLocator.RegisterService(creepRepository);
        
        var spawnerPointsRepository = new SpawnerPointsRepository(SpawnerPointsConfig.Spawners);
        serviceLocator.RegisterService(spawnerPointsRepository);
        
        ServiceLocator.Instance.RegisterService(creepRepository);

        var moveCreepsUseCase = new MoveCreepsUseCase(creepRepository, UserBasePosition);
    }
}