using UnityEngine;

namespace Core.LevelFinished.Configs
{
    [CreateAssetMenu(fileName = "LocalLevelFinishedConfig", menuName = "LocalConfigs/LocalLevelFinishedConfig", order = 1)]
    public class LocalLevelFinishedConfig
    {
        public LevelFinishedConfig LevelFinishedConfig => _levelFinishedConfig;

        [SerializeField] LevelFinishedConfig _levelFinishedConfig;
    }
}