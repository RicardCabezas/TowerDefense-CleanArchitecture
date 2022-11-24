using Core.LevelFinished.Configs;
using UnityEngine;

[CreateAssetMenu(fileName = "LocalLevelFinishedConfig", menuName = "LocalConfigs/LevelFinishedConfig", order = 1)]
public class LocalLevelFinishedConfig : ScriptableObject
{
    public LevelFinishedConfig LevelFinishedConfig => _levelFinishedConfig;

    [SerializeField] LevelFinishedConfig _levelFinishedConfig;
}
