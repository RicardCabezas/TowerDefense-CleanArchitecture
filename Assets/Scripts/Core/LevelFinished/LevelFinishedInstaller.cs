using Core.LevelFinished.UseCases;
using UnityEngine;

namespace Core.LevelFinished
{
    public class LevelFinishedInstaller : MonoBehaviour
    {
        public LocalLevelFinishedConfig LocalLevelFinishedConfig;
        
        public void Install()
        {
            var repository = new LevelFinishedRepository(LocalLevelFinishedConfig.LevelFinishedConfig);
            var levelFailedUseCase = new LevelFailedUseCase(repository);
        }
    }
}