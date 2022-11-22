using System;
using System.Collections.Generic;
using Core.Base;
using Core.LevelFinished;
using ScreenMachine;
using UnityEngine;

public class BaseCampInstaller : MonoBehaviour
{
    public LocalBaseCampConfig BaseCampLocalConfig;
    public LocalLevelFinishedConfig LevelFinishedLocalConfig;

    public void Install(ref Dictionary<Type, object> repositories, ScreenMachineImplementation screenMachine)
    {
        
        var baseCampRepository = new BaseCampRepository(BaseCampLocalConfig.BaseCampConfig);
        repositories[typeof(BaseCampRepository)] = baseCampRepository;
        
        var levelFinishedRepository = new LevelFinishedRepository(LevelFinishedLocalConfig.LevelFinishedConfig);
        repositories[typeof(LevelFinishedRepository)] = levelFinishedRepository;
        
        var baseCampReceivesDamageUseCase =
            new BaseCampReceivesDamageUseCase(baseCampRepository, levelFinishedRepository, screenMachine);
    }
}