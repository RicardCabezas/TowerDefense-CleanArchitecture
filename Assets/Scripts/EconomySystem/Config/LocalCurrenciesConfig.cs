using UnityEngine;

namespace EconomySystem.Config
{
    [CreateAssetMenu(fileName = "CurrenciesConfig", menuName = "LocalConfigs/CurrenciesConfig", order = 1)]
    public class LocalCurrenciesConfig : ScriptableObject
    {
        public CurrenciesConfig CurrenciesConfig => _currenciesConfig;

        [SerializeField] CurrenciesConfig _currenciesConfig;
    }
}