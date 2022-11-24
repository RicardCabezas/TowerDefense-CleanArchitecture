using Core.BaseCamp;
using Core.Creeps;
using Core.Currencies;
using Core.LevelFinished;
using Core.Turrets;
using Core.Waves;
using EconomySystem;
using EconomySystem.Currencies.SoftCurrency;
using Events;
using UnityEngine;

namespace Core.Installer
{
    public class GameInstaller : MonoBehaviour
    {
        public CreepsInstaller CreepsInstaller;
        public WavesInstaller WavesInstaller;
        public BaseCampInstaller BaseCampInstaller;
        public LevelFinishedInstaller LevelFinishedInstaller;
        public TurretsInstaller TurretsInstaller;
        public CurrenciesInstaller CurrenciesInstaller;

        void Start()
        { 
            IEventDispatcher eventDispatcher = new EventDispatcher();
            ServiceLocator.ServiceLocator.Instance.RegisterService(eventDispatcher);

            var assetCatalog = new AssetCatalog.AssetCatalog();
            ServiceLocator.ServiceLocator.Instance.RegisterService(assetCatalog);
        
            IEconomySystem<SoftCurrency> softCurrencySystem = new EconomySystemSoftCurrency();
            ServiceLocator.ServiceLocator.Instance.RegisterService(softCurrencySystem);
        
            CreepsInstaller.Install();
            WavesInstaller.Install();
            BaseCampInstaller.Install();
            TurretsInstaller.Install();
            CurrenciesInstaller.Install();
            LevelFinishedInstaller.Install();
        }
    }
}