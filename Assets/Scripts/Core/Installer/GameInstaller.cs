using System;
using System.Collections.Generic;
using Core.AssetCatalog;
using Core.LevelFinished;
using Events;
using UnityEngine;

public class GameInstaller : MonoBehaviour
{
    public CreepsInstaller CreepsInstaller;
    public WavesInstaller WavesInstaller;
    public BaseCampInstaller BaseCampInstaller;
    public LevelFinishedInstaller LevelFinishedInstaller;
    
    private Dictionary<Type, object> _repositories = new Dictionary<Type, object>();

    void Start()
    { 
        IEventDispatcher eventDispatcher = new EventDispatcher();
        ServiceLocator.Instance.RegisterService(eventDispatcher);

        var assetCatalog = new AssetCatalog();
        ServiceLocator.Instance.RegisterService(assetCatalog);

        //TODO: move global services to a context
        
        CreepsInstaller.Install(ref _repositories);
        WavesInstaller.Install(ref _repositories);
        BaseCampInstaller.Install(ref _repositories);
        LevelFinishedInstaller.Install();
    }
}