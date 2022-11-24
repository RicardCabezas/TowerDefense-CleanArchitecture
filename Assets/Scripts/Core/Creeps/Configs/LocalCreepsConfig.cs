using UnityEngine;

namespace Core.Creeps.Configs
{
    [CreateAssetMenu(fileName = "LocalCreepsConfig", menuName = "LocalConfigs/CreepsConfig", order = 1)]
    public class LocalCreepsConfig : ScriptableObject
    {
        public CreepsConfig CreepsConfig => _creepsConfig;

        [SerializeField] CreepsConfig _creepsConfig;
    }
}
