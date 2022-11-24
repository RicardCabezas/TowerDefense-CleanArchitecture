using Core.Currencies.Views;
using EconomySystem;
using EconomySystem.Config;
using EconomySystem.Currencies.SoftCurrency;
using UnityEngine;

namespace Core.Currencies
{
    public class CurrenciesInstaller : MonoBehaviour
    {
        [SerializeField] private SoftCurrencyView _view;
        [SerializeField] private LocalCurrenciesConfig LocalCurrenciesConfig;
        public void Install()
        {
            IEconomySystem<SoftCurrency> softCurrencySystem = new EconomySystemSoftCurrency();
            ServiceLocator.ServiceLocator.Instance.RegisterService(softCurrencySystem);
            
            softCurrencySystem.AddCurrency(LocalCurrenciesConfig.CurrenciesConfig.InitialSoftCurrency);
            
            var softCurrencyPresenter = new SoftCurrencyPresenter(_view);
        }
    }
}