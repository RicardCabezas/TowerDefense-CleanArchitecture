using UnityEngine;
using ScreenMachine;
using States;

public class GameInstaller : MonoBehaviour
{
    public WavesLocalConfig WavesLocalConfig;
    public LocalCreepsConfig CreepsLocalConfig;

    void Start()
    {
        var creepRepository = new CreepRepository(CreepsLocalConfig.CreepsConfig);
        var wavesRepository = new WavesRepository(WavesLocalConfig.WavesConfig); //TODO: think how flow would work on server
        
        var spawnCreepUseCase = new SpawnCreepUseCase();
        var spawnWaveUseCase = new SpawnWaveUseCase(spawnCreepUseCase);
        var wavesService = new WavesService(wavesRepository, spawnWaveUseCase);

        var screenMachine = new ScreenMachineImplementation();
        
        screenMachine.PushState(new GameplayState(screenMachine, wavesService));
    }
}