using System;
using System.Collections.Generic;
using Core.Waves;
using UnityEngine;

public class WavesInstaller : MonoBehaviour
{
    public WavesLocalConfig WavesLocalConfig;
    public WavesView WavesView;

    public void Install(ref Dictionary<Type, object> repositories)
    {
        var wavesRepository = new WavesRepository(WavesLocalConfig.WavesConfig, WavesView); //TODO: think how flow would work on server
        repositories[typeof(WavesRepository)] = wavesRepository;

        var creepRepository = (CreepRepository)repositories[typeof(CreepRepository)];
        var spawnerPointsRepository = (SpawnerPointsRepository)repositories[typeof(SpawnerPointsRepository)];
        
        var spawnWaveUseCase = new SpawnWaveUseCase(wavesRepository, creepRepository, spawnerPointsRepository);
        
        StartGameplay(spawnWaveUseCase);
    }

    private static void StartGameplay(SpawnWaveUseCase spawnWaveUseCase)
    {
        spawnWaveUseCase.SpawnCreepsInWave(); //TODO: change by a star game event and subscribe in UseCase
    }
}