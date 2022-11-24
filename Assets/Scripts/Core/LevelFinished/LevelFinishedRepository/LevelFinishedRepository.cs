using Core.AssetCatalog;
using Core.LevelFinished.Configs;
using Core.LevelFinished.Views;
using Events;
using UnityEngine;

public class LevelFinishedRepository
{
    private readonly LevelFinishedConfig _levelFinishedConfig;
    private readonly AssetCatalog _assetCatalog;

    public LevelFinishedRepository(LevelFinishedConfig levelFinishedConfig)
    {
        _levelFinishedConfig = levelFinishedConfig;
        _assetCatalog = ServiceLocator.Instance.GetService<AssetCatalog>();
    }

    public void CreateLevelFailedScreen()
    {
        var screen = _assetCatalog.LoadResource<LevelFailedView>(_levelFinishedConfig.LevelFailedScreenPath);
        var view = Object.Instantiate(screen);
        var presenter = new LevelFailedPresenter(view);
    }
    
    public void CreateLevelCompletedScreen()
    {
        var screen = _assetCatalog.LoadResource<LevelCompletedView>(_levelFinishedConfig.LevelCompletedScreenPath);
        var view = Object.Instantiate(screen);
        var presenter = new LevelCompletedPresenter(view);
    }
}
