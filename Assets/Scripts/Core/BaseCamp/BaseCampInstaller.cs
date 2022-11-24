using Core.BaseCamp.Configs;
using Core.BaseCamp.Entities;
using Core.BaseCamp.UseCases;
using Core.LevelFinished.Configs;
using Core.LevelFinished.LevelFinishedRepository;
using UnityEngine;

namespace Core.BaseCamp
{
    public class BaseCampInstaller : MonoBehaviour
    {
        public LocalBaseCampConfig BaseCampLocalConfig;
        public LocalLevelFinishedConfig LevelFinishedLocalConfig;

        public void Install()
        {
            var serviceLocator = ServiceLocator.ServiceLocator.Instance;

            var baseCampRepository = new BaseCampRepository(BaseCampLocalConfig.BaseCampConfig);
            serviceLocator.RegisterService(baseCampRepository);

            var levelFinishedRepository = new LevelFinishedRepository(LevelFinishedLocalConfig.LevelFinishedConfig);
            serviceLocator.RegisterService(levelFinishedRepository);

            var baseCampReceivesDamageUseCase =
                new BaseCampReceivesDamageUseCase(baseCampRepository, levelFinishedRepository);
        }
    }
}