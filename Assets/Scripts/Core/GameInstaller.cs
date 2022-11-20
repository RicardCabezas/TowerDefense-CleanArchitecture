using UnityEngine;
using ScreenMachine;
using States;

public class GameInstaller : MonoBehaviour
{
    public WavesLocalConfig WavesLocalConfig;
    public LocalCreepsConfig CreepsLocalConfig;
    public LevelSpawnerPointsLocalConfig SpawnerPointsConfig;
    public Transform UserBasePosition; //TODO: make a config
    void Start()
    {
        var creepRepository = new CreepRepository(CreepsLocalConfig.CreepsConfig);
        var wavesRepository = new WavesRepository(WavesLocalConfig.WavesConfig); //TODO: think how flow would work on server
        var spawnerPointsRepository = new SpawnerPointsRepository(SpawnerPointsConfig.Spawners);
        
        var moveCreepUseCase = new MoveCreepUseCase(UserBasePosition);
        var spawnCreepUseCase = new SpawnCreepUseCase(moveCreepUseCase, creepRepository, spawnerPointsRepository);
        var spawnWaveUseCase = new SpawnWaveUseCase(spawnCreepUseCase);
        var wavesService = new WavesService(wavesRepository, spawnWaveUseCase);

        var screenMachine = new ScreenMachineImplementation();
        
        screenMachine.PushState(new GameplayState(screenMachine, wavesService));
    }
}