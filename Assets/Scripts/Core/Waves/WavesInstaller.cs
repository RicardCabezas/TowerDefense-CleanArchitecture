using System;
using System.Collections.Generic;
using Core.Waves;
using Events;
using UnityEngine;

public class WavesInstaller : MonoBehaviour
{
    public WavesLocalConfig WavesLocalConfig;
    public WavesView WavesView;

    public void Install()
    {
        var serviceLocator = ServiceLocator.Instance;

        var wavesRepository = new WavesRepository(WavesLocalConfig.WavesConfig, WavesView); //TODO: think how flow would work on server
        serviceLocator.RegisterService(wavesRepository);

        var spawnWaveUseCase = new SpawnWaveUseCase(wavesRepository);
        
        StartGameplay(spawnWaveUseCase);
    }

    private static void StartGameplay(SpawnWaveUseCase spawnWaveUseCase)
    {
        spawnWaveUseCase.SpawnCreepsInWave(); //TODO: change by a star game event and subscribe in UseCase
    }
}