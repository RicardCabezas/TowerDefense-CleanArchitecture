using UnityEngine;

namespace Core.Waves.Config
{
    [CreateAssetMenu(fileName = "LocalWavesConfig", menuName = "LocalConfigs/WavesConfig", order = 1)]
    public class WavesLocalConfig : ScriptableObject
    {
        public WavesConfig WavesConfig => _wavesConfig;

        [SerializeField] WavesConfig _wavesConfig;
    }
}