using UnityEngine;

namespace Core.LevelFinished
{
    [CreateAssetMenu(fileName = "LocalLevelFinishedConfig", menuName = "LocalConfigs/LevelFinishedConfig", order = 1)]
    public class LocalLevelFinishedConfig : ScriptableObject
    {
        public LevelFinishedConfig LevelFinishedConfig => _levelFinishedConfig;

        [SerializeField] LevelFinishedConfig _levelFinishedConfig;
    }

    public class LevelFinishedRepository
    {
        private readonly LevelFinishedConfig _config;

        public LevelFinishedRepository(LevelFinishedConfig config)
        {
            _config = config;
        }

        public GameObject GetLevelFailPopup()
        {
            return _config.LevelFailPopup;
        }
    }
}