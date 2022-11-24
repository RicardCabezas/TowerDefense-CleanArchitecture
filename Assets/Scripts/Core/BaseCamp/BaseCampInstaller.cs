using System;
using System.Collections.Generic;
using Core.Base;
using Core.LevelFinished;
using Events;
using UnityEngine;

public class BaseCampInstaller : MonoBehaviour
{
    public LocalBaseCampConfig BaseCampLocalConfig;
    public LocalLevelFinishedConfig LevelFinishedLocalConfig;

    public void Install()
    {
        var serviceLocator = ServiceLocator.Instance;

        var baseCampRepository = new BaseCampRepository(BaseCampLocalConfig.BaseCampConfig);
        serviceLocator.RegisterService(baseCampRepository);

        var levelFinishedRepository = new LevelFinishedRepository(LevelFinishedLocalConfig.LevelFinishedConfig);
        serviceLocator.RegisterService(levelFinishedRepository);

        var baseCampReceivesDamageUseCase =
            new BaseCampReceivesDamageUseCase(baseCampRepository, levelFinishedRepository);
    }
}