using System;
using System.Collections.Generic;
using Core.Waves;
using Core.Waves.Controllers;
using Events;
using UnityEngine;

public class WavesInstaller : MonoBehaviour
{
    public WavesLocalConfig WavesLocalConfig;
    public WavesView WavesView;

    public void Install()
    {
        var serviceLocator = ServiceLocator.Instance;

        var wavesRepository = new WavesRepository(WavesLocalConfig.WavesConfig, WavesView); //TODO: change this
        serviceLocator.RegisterService(wavesRepository);

        var spawnWaveUseCase = new SpawnWaveUseCase(wavesRepository);
        var updateWaveUseCase = new UpdateWaveUseCase(wavesRepository, spawnWaveUseCase);

        var wavesController = new WavesController(updateWaveUseCase);
        
        spawnWaveUseCase.SpawnCreepsInWave();
    }
}