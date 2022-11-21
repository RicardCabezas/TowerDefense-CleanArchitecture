using Core.Base;
using Core.LevelFinished;
using Core.Waves;
using Events;
using UnityEngine;
using ScreenMachine;
using States;

public class GameInstaller : MonoBehaviour
{
    public WavesLocalConfig WavesLocalConfig;
    public LocalCreepsConfig CreepsLocalConfig;
    public LevelSpawnerPointsLocalConfig SpawnerPointsConfig;
    public LocalBaseCampConfig BaseCampLocalConfig;
    public LocalLevelFinishedConfig LevelFinishedLocalConfig;
    
    
    public Transform UserBasePosition; //TODO: make a config
    public WavesView WavesView; //TODO: move to a new installer
    void Start()
    { 
        IEventDispatcher eventDispatcher = new EventDispatcher();
        ServiceLocator.Instance.RegisterService(eventDispatcher);
        //TODO: move global services to a context
        
        var screenMachine = new ScreenMachineImplementation();
        
        //Repositories
        var creepRepository = new CreepRepository(CreepsLocalConfig.CreepsConfig);
        var wavesRepository = new WavesRepository(WavesLocalConfig.WavesConfig, WavesView); //TODO: think how flow would work on server
        var spawnerPointsRepository = new SpawnerPointsRepository(SpawnerPointsConfig.Spawners);
        var baseCampRepository = new BaseCampRepository(BaseCampLocalConfig.BaseCampConfig);
        var levelFinishedRepository = new LevelFinishedRepository(LevelFinishedLocalConfig.LevelFinishedConfig);
        
        //UseCase
        var moveCreepsUseCase = new MoveCreepsUseCase(creepRepository, UserBasePosition);
        var spawnWaveUseCase = new SpawnWaveUseCase(eventDispatcher, wavesRepository, creepRepository, spawnerPointsRepository);
        
        var baseCampReceivesDamageUseCase =
            new BaseCampReceivesDamageUseCase(baseCampRepository, levelFinishedRepository, screenMachine, eventDispatcher);
        
        StartGame(screenMachine, spawnWaveUseCase);
    }

    private void StartGame(ScreenMachineImplementation screenMachine, SpawnWaveUseCase spawnWaveUseCase)
    {
        screenMachine.PushState(new GameplayState(screenMachine, spawnWaveUseCase));
    }
}