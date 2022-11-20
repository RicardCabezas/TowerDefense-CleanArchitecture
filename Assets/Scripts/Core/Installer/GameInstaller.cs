using Core.Base;
using Core.LevelFinished;
using UnityEngine;
using ScreenMachine;
using States;

public class GameInstaller : MonoBehaviour
{
    public WavesLocalConfig WavesLocalConfig;
    public LocalCreepsConfig CreepsLocalConfig;
    public LevelSpawnerPointsLocalConfig SpawnerPointsConfig;
    public Transform UserBasePosition; //TODO: make a config
    public LocalBaseCampConfig BaseCampLocalConfig;
    public LocalLevelFinishedConfig LevelFinishedLocalConfig;
    void Start()
    {
        var screenMachine = new ScreenMachineImplementation();
        
        //Repositories
        var creepRepository = new CreepRepository(CreepsLocalConfig.CreepsConfig);
        var wavesRepository = new WavesRepository(WavesLocalConfig.WavesConfig); //TODO: think how flow would work on server
        var spawnerPointsRepository = new SpawnerPointsRepository(SpawnerPointsConfig.Spawners);
        var baseCampRepository = new BaseCampRepository(BaseCampLocalConfig.BaseCampConfig);
        var levelFinishedRepository = new LevelFinishedRepository(LevelFinishedLocalConfig.LevelFinishedConfig);
        
        //UseCase
        var moveCreepUseCase = new MoveCreepUseCase(UserBasePosition);
        var spawnCreepUseCase = new SpawnCreepUseCase(moveCreepUseCase, creepRepository, spawnerPointsRepository);
        var spawnWaveUseCase = new SpawnWaveUseCase(spawnCreepUseCase);
        var wavesService = new WavesService(wavesRepository, spawnWaveUseCase);
        var baseCampReceivesDamageUseCase =
            new BaseCampReceivesDamageUseCase(baseCampRepository,  levelFinishedRepository, screenMachine);
        
        StartGame(screenMachine, wavesService);
    }

    private void StartGame(ScreenMachineImplementation screenMachine, WavesService wavesService)
    {
        screenMachine.PushState(new GameplayState(screenMachine, wavesService));
    }
}