using UnityEngine;

namespace Core.Turrets.Configs
{
    [CreateAssetMenu(fileName = "TurretsConfig", menuName = "LocalConfigs/TurretsConfig", order = 1)]
    public class LocalTurretsConfig : ScriptableObject
    {
        public TurretsConfig TurretsConfig => _turretsConfig;

        [SerializeField] TurretsConfig _turretsConfig;
    }
}