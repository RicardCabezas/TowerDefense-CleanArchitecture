using UnityEngine;

namespace Core.BaseCamp.Configs
{
    [CreateAssetMenu(fileName = "LocalBaseCampConfig", menuName = "LocalConfigs/BaseCampConfig", order = 1)]
    public class LocalBaseCampConfig : ScriptableObject
    {
        public BaseCampConfig BaseCampConfig => baseCampConfig;

        [SerializeField] BaseCampConfig baseCampConfig;
    }
}