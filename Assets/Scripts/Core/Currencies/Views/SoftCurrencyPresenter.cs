using Core.Currencies.Events;
using Core.Turrets.Events;
using Events;
using UnityEngine;

namespace Core.Currencies.Views
{
    public class SoftCurrencyPresenter : BasePresenter
    {
        private SoftCurrencyView _view;
        private IEventDispatcher _eventDispatcher;

        public SoftCurrencyPresenter(SoftCurrencyView view)
        {
            _view = view;
            
            view.CurrentAmount.text = "0";
            
            _eventDispatcher = ServiceLocator.Instance.GetService<IEventDispatcher>();
            _eventDispatcher.Subscribe<UpdateSoftCurrencyEvent>(OnSoftCurrencyAdded);

            _view.Dispose += OnViewDisposed;
        }

        private void OnViewDisposed()
        {
            _view = null;
            _eventDispatcher = null;
        }

        private void OnSoftCurrencyAdded(UpdateSoftCurrencyEvent eventInfo)
        {
            _view.CurrentAmount.text = eventInfo.CurrentAmount.ToString();
        }
    }
}