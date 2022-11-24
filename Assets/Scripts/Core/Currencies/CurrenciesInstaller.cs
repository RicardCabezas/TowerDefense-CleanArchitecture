using Core.Currencies.Views;
using UnityEngine;

namespace Core.Currencies
{
    public class CurrenciesInstaller : MonoBehaviour
    {
        [SerializeField] private SoftCurrencyView _view;
        public void Install()
        {
            var softCurrencyPresenter = new SoftCurrencyPresenter(_view);
        }
    }
}