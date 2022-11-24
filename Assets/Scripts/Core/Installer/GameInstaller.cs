using System;
using System.Collections.Generic;
using Core.AssetCatalog;
using Core.Currencies;
using Core.LevelFinished;
using Events;
using UnityEngine;

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
        ServiceLocator.Instance.RegisterService(eventDispatcher);

        var assetCatalog = new AssetCatalog();
        ServiceLocator.Instance.RegisterService(assetCatalog);
        
        IEconomySystem<SoftCurrency> softCurrencySystem = new EconomySystemSoftCurrency();
        ServiceLocator.Instance.RegisterService(softCurrencySystem);
        
        CreepsInstaller.Install();
        WavesInstaller.Install();
        BaseCampInstaller.Install();
        LevelFinishedInstaller.Install();
        TurretsInstaller.Install();
        CurrenciesInstaller.Install();
    }
}