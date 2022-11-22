using UnityEngine;

namespace Core.Turrets.Configs
{
    [CreateAssetMenu(fileName = "LocalTurretsConfig", menuName = "LocalConfigs/LocalTurretsConfig", order = 1)]
    public class LocalTurretsConfig : ScriptableObject
    {
        public TurretsConfig TurretsConfig => _turretsConfig;

        [SerializeField] TurretsConfig _turretsConfig;
    }
}