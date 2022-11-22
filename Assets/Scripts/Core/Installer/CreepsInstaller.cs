using System;
using System.Collections.Generic;
using UnityEngine;

public class CreepsInstaller : MonoBehaviour
{
    public LocalCreepsConfig CreepsLocalConfig;
    public LevelSpawnerPointsLocalConfig SpawnerPointsConfig;
    public Transform UserBasePosition; //TODO: make a config?

    public void Install(ref Dictionary<Type, object> repositories)
    {
        var creepRepository = new CreepRepository(CreepsLocalConfig.CreepsConfig);
        repositories[typeof(CreepRepository)] = creepRepository;
        
        var spawnerPointsRepository = new SpawnerPointsRepository(SpawnerPointsConfig.Spawners);
        repositories[typeof(SpawnerPointsRepository)] = spawnerPointsRepository;
        
        var moveCreepsUseCase = new MoveCreepsUseCase(creepRepository, UserBasePosition);
    }
}