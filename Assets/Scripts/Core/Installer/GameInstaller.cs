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
        [SerializeField] CreepsInstaller CreepsInstaller;
        [SerializeField] WavesInstaller WavesInstaller;
        [SerializeField] BaseCampInstaller BaseCampInstaller;
        [SerializeField] LevelFinishedInstaller LevelFinishedInstaller;
        [SerializeField] TurretsInstaller TurretsInstaller;
        [SerializeField] CurrenciesInstaller CurrenciesInstaller;

        void Start()
        { 
            IEventDispatcher eventDispatcher = new EventDispatcher();
            ServiceLocator.ServiceLocator.Instance.RegisterService(eventDispatcher);

            var assetCatalog = new AssetCatalog.AssetCatalog();
            ServiceLocator.ServiceLocator.Instance.RegisterService(assetCatalog);
        
            CurrenciesInstaller.Install();
            CreepsInstaller.Install();
            WavesInstaller.Install();
            BaseCampInstaller.Install();
            TurretsInstaller.Install();
            LevelFinishedInstaller.Install();
        }
    }
}