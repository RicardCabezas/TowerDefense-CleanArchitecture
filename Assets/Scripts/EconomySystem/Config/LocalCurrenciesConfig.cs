using UnityEngine;

namespace EconomySystem.Config
{
    [CreateAssetMenu(fileName = "LocalCurrenciesConfig", menuName = "LocalConfigs/LocalCurrenciesConfig", order = 1)]
    public class LocalCurrenciesConfig : ScriptableObject
    {
        public CurrenciesConfig CurrenciesConfig => _currenciesConfig;

        [SerializeField] CurrenciesConfig _currenciesConfig;
    }
}